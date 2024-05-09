namespace Application.Interfaces.Repository
{
    public interface IGenericRepository
    {
        public Task<T> SaveAsync<T>(T entity) where T : class;
        public Task<T> UpdateAsync<T>(T entity) where T : class;
        public Task<T> DeleteAsync<T>(T entity) where T : class;
    }
}
