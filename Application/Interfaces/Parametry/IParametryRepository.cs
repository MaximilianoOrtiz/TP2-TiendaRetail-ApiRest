namespace Application.Interfaces
{
    public interface IParametryRepository
    {
        public Task<decimal> findValueByCodigo(String codigo);
    }
}
