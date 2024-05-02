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

        public async Task<T> save<T>(T entity) where T : class
        {
            _logger.LogInformation("Init - save");
            _context.Add(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("out - se realizo el save exitosamente");
            return entity;
        }

        public async Task<T> update<T>(T entity) where T : class
        {
            _logger.LogInformation("Init - update");
            _context.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Out - se realizó la actualización exitosamente");
            return entity;
        }
        public async Task<T> delete<T>(T entity) where T : class
        {
            _logger.LogInformation("Init - delete");
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Out - se elimino exitosamente");
            return entity;
        }

    }
}
