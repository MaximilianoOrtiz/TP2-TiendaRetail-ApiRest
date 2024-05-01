using Application.Dtos;
using Application.Dtos.Product;
using Domain.Entitys;

namespace Application.Interfaces
{
    public interface IProductService
    {
        //  public List<DTOProductResponse> findProductbyIdCategory(int idCategory);
        public Task<Boolean> existProductByEqualName(string name);

        public Task<List<ProductoGetResponse>> findProductbyCategoryIdAndName(int[] categorys, string name, int limit, int offSet);

        public Task<ProductResponse> saveProduct(ProductRequest product);
    }
}
