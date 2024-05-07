using Application.Interfaces.Repository;
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

        public async Task<T> SaveAsync<T>(T entity) where T : class
        {
            _logger.LogInformation("Init - SaveAsync");
            _context.Add(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("out - se realizo el SaveAsync exitosamente");
            return entity;
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            _logger.LogInformation("Init - UpdateAsync");
            _context.Update(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Out - se realizó la actualización exitosamente");
            return entity;
        }
        public async Task<T> DeleteAsync<T>(T entity) where T : class
        {
            _logger.LogInformation("Init - DeleteAsync");
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Out - se elimino exitosamente");
            return entity;
        }

    }
}
