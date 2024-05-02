namespace Application.Interfaces
{
    public interface IGenericRepository
    {
        public Task<T> save<T>(T entity) where T : class;

        public Task<T> update<T>(T entity) where T : class;

        public Task<T> delete<T>(T entity) where T : class;
    }
}
