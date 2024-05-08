using Application.Interfaces.Repository;
using Domain.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class SaleRepositoryImpl : ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sale> FindSaleByIdAsync(int saleId)
        {
            return _context.Sale
               .Include(sale => sale.SaleProducts)
               .ThenInclude(saleProduct => saleProduct.Product)
               .Where(sale => sale.SaleId == saleId)
               .FirstOrDefault();
        }
    }
}
