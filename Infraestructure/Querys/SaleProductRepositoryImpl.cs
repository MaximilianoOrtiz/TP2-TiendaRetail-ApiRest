using Application.Interfaces.Repository;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Querys
{

    public class SaleProductRepositoryImpl : ISaleProductRepository
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<SaleProductRepositoryImpl> _logger;

        public SaleProductRepositoryImpl(ApplicationDbContext context, ILogger<SaleProductRepositoryImpl> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> HasProductAssociatedAsync(Guid productId)
        {
            _logger.LogInformation("Init - HasProductAssociatedAsync");

            bool hasProductAssociated = false;

            var products = (from saleProduct in _context.SaleProducts
                            where saleProduct.ProductId == productId
                            select saleProduct).FirstOrDefault();

            if (products != null)
            {
                hasProductAssociated = true;
            }
            _logger.LogInformation("HasProductAssociatedAsync: " + hasProductAssociated);
            _logger.LogInformation("Out - HasProductAssociatedAsync");
            return hasProductAssociated;
        }
    }
}
