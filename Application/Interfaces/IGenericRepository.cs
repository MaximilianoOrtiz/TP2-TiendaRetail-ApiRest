namespace Application.Interfaces
{
    public interface IGenericRepository
    {
        Task<T> save<T>(T entity) where T : class;
    }
}
