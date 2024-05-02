namespace Application.Interfaces.ISalesProducts
{
    public interface ISaleProductRepository
    {
        public Task<bool> hasProductAssociated(Guid productId);
    }
}
