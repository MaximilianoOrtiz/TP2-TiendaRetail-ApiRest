using Application.Dtos;
using Application.Dtos.Product;

namespace Application.Interfaces.Service
{
    public interface IProductService
    {
        //  public List<DTOProductResponse> findProductbyIdCategory(int idCategory);
        public Task<bool> ExistProductByEqualNameAsync(string name);

        public Task<List<ProductoGetResponse>> FindProductByCategoryIdAndNameAsync(int[] categorys, string name, int limit, int offSet);

        public Task<ProductResponse> SaveProductAsync(ProductRequest product);

        public Task<ProductResponse> FindProductbyIdAsync(Guid productoId);

        public Task<ProductResponse> UpdateProductAsync(ProductRequest productRequest, Guid productId);

        public Task<ProductResponse> DeleteProductAsync(Guid productId);
    }
}
