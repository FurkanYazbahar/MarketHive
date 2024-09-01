namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id) : IQuery<GetPruductByIdResult>;
    public record GetPruductByIdResult(Product Product);
    internal class GetProductByIdQueryHandler
        (IDocumentSession session)
        : IQueryHandler<GetProductByIdQuery, GetPruductByIdResult>
    {
        public async Task<GetPruductByIdResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException(query.Id);
            }

            return new GetPruductByIdResult(product);
        }
    }
}
