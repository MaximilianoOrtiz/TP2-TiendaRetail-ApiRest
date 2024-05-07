using Domain.Entitys;

namespace Application.Interfaces.Repository
{
    public interface IProductRepository
    {
        //  public List<Product> findProductbyIdCategory(int idCategory);

        public Task<List<Product>> FindProductByCategoryIdAndNameAsync(int categorys, string name);

        public Task<List<Product>> FindProductByNameAsync(string name);

        public Task<Product> FindProductByEqualNameAsync(string name);

        public Task<Product> FindProductByIdAsync(Guid productoId);

    }
}
