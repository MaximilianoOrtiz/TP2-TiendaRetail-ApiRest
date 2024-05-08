using Application.Interfaces.Repository;
using Application.Interfaces.Service;

namespace Application.ServiceImpl
{
    public class SaleProductServiceImpl : ISaleProductService
    {
        private readonly ISaleProductRepository _saleProductRepository;

        public SaleProductServiceImpl(ISaleProductRepository saleProductRepository)
        {
            _saleProductRepository = saleProductRepository;
        }

        public async Task<bool> HasProductAssociatedAsync(Guid productId)
        {
            return await _saleProductRepository.HasProductAssociatedAsync(productId);
        }
    }
}
