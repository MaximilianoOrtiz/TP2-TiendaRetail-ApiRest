namespace Application.Interfaces.Repository
{
    public interface ISaleProductRepository
    {
        public Task<bool> HasProductAssociatedAsync(Guid productId);

        //public Task<List<Sale>>
    }
}
