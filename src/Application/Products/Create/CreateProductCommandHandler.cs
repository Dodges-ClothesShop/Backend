using MediatR;

namespace Dodges.ClothesShop.Application.Products.Create;

internal sealed class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
    }
}
