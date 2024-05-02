using Application.Interfaces.IParametry;
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

        public async Task<decimal> findValueByCodigo(string codigo)
        {
            return await (from parametry in _context.Parametries
                          where parametry.Codigo.Equals(codigo)
                          select parametry.Value)
                                  .FirstOrDefaultAsync();
        }
    }
}
