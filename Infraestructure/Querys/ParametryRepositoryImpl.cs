using Application.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.Querys
{
    public class ParametryRepositoryImpl : IParametryRepository
    {
        private readonly ApplicationDbContext _context;

        public ParametryRepositoryImpl(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<decimal> FindValueByCodigoAsync(string codigo)
        {
            return await (from parametry in _context.Parametry
                          where parametry.Codigo.Equals(codigo)
                          select parametry.Value)
                                  .FirstOrDefaultAsync();
        }
    }
}
