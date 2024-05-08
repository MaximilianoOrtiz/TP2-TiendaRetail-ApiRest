namespace Application.Interfaces.Service
{
    public interface ISaleProductService
    {
        public Task<bool> HasProductAssociatedAsync(Guid productId);
    }
}
