namespace Application.Interfaces
{
    public interface IGenericRepository
    {
        T save<T>(T entity) where T : class;
    }
}
