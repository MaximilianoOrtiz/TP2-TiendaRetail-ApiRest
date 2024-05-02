using Application.Interfaces.ISalesProducts;
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

        public async Task<bool> hasProductAssociated(Guid productId)
        {
            _logger.LogInformation("Init - hasProductAssociated");

            bool hasProductAssociated = false;

            var products = (from saleProduct in _context.SaleProducts
                            where saleProduct.ProductId == productId
                            select saleProduct).FirstOrDefault();

            if (products != null)
            {
                hasProductAssociated = true;
            }
            _logger.LogInformation("hasProductAssociated: " + hasProductAssociated);
            _logger.LogInformation("Out - hasProductAssociated");
            return hasProductAssociated;
        }
    }
}
