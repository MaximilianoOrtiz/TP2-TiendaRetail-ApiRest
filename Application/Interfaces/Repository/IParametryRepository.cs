namespace Application.Interfaces.Repository
{
    public interface IParametryRepository
    {
        public Task<decimal> FindValueByCodeAsync(string codigo);
    }
}
