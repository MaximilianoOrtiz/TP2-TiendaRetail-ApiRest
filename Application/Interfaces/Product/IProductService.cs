using Application.Dtos;
using Application.Dtos.Product;

namespace Application.Interfaces
{
    public interface IProductService
    {
        //  public List<DTOProductResponse> findProductbyIdCategory(int idCategory);
        public Task<Boolean> existProductByEqualName(string name);

        public Task<List<ProductoGetResponse>> findProductbyCategoryIdAndName(int[] categorys, string name, int limit, int offSet);

        public Task<ProductResponse> saveProduct(ProductRequest product);

        public Task<ProductResponse> findProductbyId(Guid productoId);

        public Task<ProductResponse> updateProduct(ProductRequest productRequest, Guid productId);

    }
}
