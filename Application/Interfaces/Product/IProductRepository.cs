using Domain.Entitys;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        public List<Product> findProductbyIdCategory(int idCategory);
        public Task<Product> findProductById(Guid id);
    }
}
