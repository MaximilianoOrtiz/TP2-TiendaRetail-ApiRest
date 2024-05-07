namespace Application.Interfaces.Repository
{
    public interface IParametryRepository
    {
        public Task<decimal> FindValueByCodigoAsync(string codigo);
    }
}
