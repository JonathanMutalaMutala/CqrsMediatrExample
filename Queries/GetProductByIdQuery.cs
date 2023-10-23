using MediatR;

namespace CqrsMediatrExample.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<Product>;
}
