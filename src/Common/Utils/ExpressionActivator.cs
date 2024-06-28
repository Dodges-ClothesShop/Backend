using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace Dodges.ClothesShop.Common.Utils;

public sealed class ExpressionActivator
{
    private static readonly ConcurrentDictionary<Type, Func<object>> Cache = new();

    public static T Create<T>() => GenericFactoryCache<T>.CreateInstance();

    public static T Create<TParam, T>(TParam parameter) => GenericFactoryCache<TParam, T>.CreateInstance(parameter);

    public static object Create(Type instanceType)
    {
        var factory = Cache.GetOrAdd(instanceType, BuildFactory);
        return factory();
    }

    private static Func<T> BuildFactory<T>(Type instanceType)
    {
        var constructorExpression = Expression.New(instanceType);
        var lambdaExpression = Expression.Lambda<Func<T>>(constructorExpression);
        return lambdaExpression.Compile();
    }

    private static Func<TParam, T> BuildFactory<TParam, T>(Type instanceType)
    {
        static bool HasSingleParameter<TParam1>(ConstructorInfo ctor)
        {
            var parameters = ctor.GetParameters();
            return parameters.Length == 1 && parameters[0].ParameterType.IsAssignableFrom(typeof(TParam1));
        }

        var constructor = instanceType
            .GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
            .SingleOrDefault(HasSingleParameter<TParam>)
            ?? throw new InvalidOperationException($"Can't find suitable constructor: {instanceType}({typeof(TParam)})");

        var parameterExpressions = constructor
            .GetParameters()
            .Select(parameter => Expression.Parameter(parameter.ParameterType, parameter.Name))
            .ToArray();

        var constructorExpression = Expression.New(constructor, parameterExpressions.ToArray<Expression>());
        var lambdaExpression = Expression.Lambda(constructorExpression, parameterExpressions);
        var lambda = lambdaExpression.Compile();
        return (Func<TParam, T>)lambda;
    }

    private static Func<object> BuildFactory(Type instanceType) => BuildFactory<object>(instanceType);

    private static class GenericFactoryCache<T>
    {
        public static readonly Func<T> CreateInstance = BuildFactory<T>(typeof(T));
    }

    private static class GenericFactoryCache<TParam, T>
    {
        public static readonly Func<TParam, T> CreateInstance = BuildFactory<TParam, T>(typeof(T));
    }
}
