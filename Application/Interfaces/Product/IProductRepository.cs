using Domain.Entitys;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        //  public List<Product> findProductbyIdCategory(int idCategory);
      
        public Task<List<Product>> findProductByCategoryIdAndName(int categorys, string name);

        public Task<List<Product>> findProductByName(string name);

        public Task<Product> findProductByEqualName(string name);

    }
}
