using Application.Dtos.Product;

namespace Application.Interfaces
{
    public interface IProductService
    {
        //  public List<DTOProductResponse> findProductbyIdCategory(int idCategory);
        // public Task<Product> findProductById(Guid id);

        public Task<List<ProductoGetResponse>> findProductbyCategoryIdAndName(int[] categorys, string name, int limit, int offSet);
    }
}
