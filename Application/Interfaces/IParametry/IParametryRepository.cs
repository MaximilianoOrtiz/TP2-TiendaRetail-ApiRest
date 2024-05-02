namespace Application.Interfaces.IParametry
{
    public interface IParametryRepository
    {
        public Task<decimal> findValueByCodigo(String codigo);
    }
}
