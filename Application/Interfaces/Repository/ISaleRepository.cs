using Domain.Entitys;

namespace Application.Interfaces.Repository
{
    public interface ISaleRepository
    {
        public Task<Sale> FindSaleByIdAsync(int saleId);
    }
}
