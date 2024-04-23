using Application.Interfaces;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Commands
{
    public class GenericRepositoryImpl : IGenericRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GenericRepositoryImpl> _logger;

        public GenericRepositoryImpl(ApplicationDbContext dbContext, ILogger<GenericRepositoryImpl> logger)
        {
            _context = dbContext;
            _logger = logger;   
        }

        public T save<T>(T entity) where T : class
        {
            _logger.LogInformation("Init - save");
            _context.Add(entity);
            _context.SaveChanges();
            _logger.LogInformation("out - se realizo el save exitosamente");
            _logger.LogInformation($"{entity.ToString()}");
            return entity;
        }
    }
}
