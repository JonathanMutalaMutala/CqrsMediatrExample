using MediatR;

namespace CqrsMediatrExample.Commands
{
    public record AddProductCommand : IRequest<Product>
    {
        public Product Product { get; set; }    
    }
}
