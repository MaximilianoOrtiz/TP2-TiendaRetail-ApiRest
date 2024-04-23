using Application.Dtos.Product;
using Domain.Entitys;

namespace Application.Interfaces
{
    public interface IProductService
    {
        public List<DTOProductResponse> findProductbyIdCategory(int idCategory);
        public Task<Product> findProductById (Guid id);
    }
}
