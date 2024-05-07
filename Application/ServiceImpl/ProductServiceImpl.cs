using Application.Dtos;
using Application.Dtos.Product;
using Application.Exceptions;
using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using AutoMapper;
using Domain.Entitys;
using Microsoft.Extensions.Logging;

namespace Application.UseCase
{
    public class ProductServiceImpl : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IGenericRepository _genericRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly ILogger<ProductServiceImpl> _logger;
        private readonly IMapper _mapper;

        public ProductServiceImpl(IProductRepository repository,
                                  ILogger<ProductServiceImpl> logger,
                                  IMapper mapper,
                                  IGenericRepository genericRepository,
                                  ICategoryRepository categoryRepository,
                                  ISaleProductRepository saleProductRepository)
        {
            _productRepository = repository;
            _logger = logger;
            _mapper = mapper;
            _genericRepository = genericRepository;
            _categoryRepository = categoryRepository;
            _saleProductRepository = saleProductRepository;
        }

        public async Task<List<ProductoGetResponse>> FindProductByCategoryIdAndNameAsync(int[] categorys, string name, int limit, int offSet)
        {
            _logger.LogInformation("Init - find Product by CategoryId and Name");
            _logger.LogInformation("Datos de entrada --> Category.Length: " + categorys.Length
                + " Name: " + name
                + " limit: " + limit
                + " offSet: " + offSet);

            List<Product> listProducts = new List<Product>();
            List<ProductoGetResponse> response = new List<ProductoGetResponse>();

            if (categorys.Length > 0)
            {
                //Traigo todos los productos a partir de las categorias seleccionadas
                foreach (int category in categorys)
                {
                    listProducts = listProducts.Concat(
                        await _productRepository.FindProductByCategoryIdAndNameAsync(category, name)).ToList();
                }
                _logger.LogInformation($"Cantidad de productos encontrados por todas las categorias ingresadas: {listProducts.Count}");
            }
            else
            {
                if (!string.IsNullOrEmpty(name))
                {
                    listProducts = await _productRepository.FindProductByNameAsync(name);
                    _logger.LogInformation($"Cantidad de productos encontrados por nombre ingresado: {listProducts.Count}");
                }
                else return response;
            }

            _logger.LogInformation("Inicio paginación");
            List<Product> productsTemp = new List<Product>();
            productsTemp = listProducts.Skip(offSet).Take(limit).ToList();

            _logger.LogInformation($"Total de productos paginados: {productsTemp.Count}");

            //Realizo el mapeo 
            foreach (Product product in productsTemp)
            {
                response.Add(_mapper.Map<ProductoGetResponse>(product));
            }
            _logger.LogInformation("Out - find Product by CategoryId and Name");
            return response;
        }

        public async Task<ProductResponse> SaveProductAsync(ProductRequest productRequest)
        {
            _logger.LogInformation("Init - SaveProductAsync");
            Category category = await _categoryRepository.FindCategoryByIdAsync(productRequest.CategoryId);
            Product product = new Product();

            product = _mapper.Map<Product>(productRequest);
            product.Category = category;

            _logger.LogInformation("Out - SaveProductAsync");
            return _mapper.Map<ProductResponse>(await _genericRepository.SaveAsync(product));
        }

        public async Task<bool> ExistProductByEqualNameAsync(string name)
        {
            Product product = await _productRepository.FindProductByEqualNameAsync(name);
            if (product == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ProductResponse> FindProductbyIdAsync(Guid productoId)
        {
            Product product = await _productRepository.FindProductByIdAsync(productoId);
            if (product == null) { return null; }
            product.Category = await _categoryRepository.FindCategoryByIdAsync(product.CategoryId);

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> UpdateProductAsync(ProductRequest productRequest, Guid productId)
        {
            _logger.LogInformation("Init - UpdateProductAsync");

            ProductResponse productResponse = new ProductResponse();
            Product productUpdate = new Product();

            Product product = await _productRepository.FindProductByIdAsync(productId);
            if (product == null)
            {
                return null;
            }
            else
            {
                //Si el nombre fue modificado verifico que el nuevo no pertenezca a un producto existente.
                if (product.Name != productRequest.Name)
                {
                    Product productConflit = await _productRepository.FindProductByEqualNameAsync(productRequest.Name);
                    if (productConflit != null)
                    {
                        throw new CustomException("Ya existe un producto con ese nombre");
                    }
                }

                product.Name = productRequest.Name;
                product.Description = productRequest.Description;
                product.CategoryId = productRequest.CategoryId;
                product.Price = productRequest.Price;
                product.Discount = productRequest.Discount;
                product.ImageUrl = productRequest.ImageUrl;

                productUpdate = await _genericRepository.UpdateAsync(product);
                productUpdate.Category = await _categoryRepository.FindCategoryByIdAsync(productRequest.CategoryId);

                productResponse = _mapper.Map<ProductResponse>(productUpdate);
            }

            _logger.LogInformation("Out - UpdateProductAsync");
            return productResponse;
        }

        public async Task<ProductResponse> DeleteProductAsync(Guid productId)
        {
            _logger.LogInformation("Init - DeleteProductAsync");
            ProductResponse productResponse = new ProductResponse();
            Product product = await _productRepository.FindProductByIdAsync(productId);

            if (product == null)
            {
                return null;
            }
            if (await _saleProductRepository.HasProductAssociatedAsync(productId))
            {
                throw new CustomException("No se puede eliminar un producto que este asiciado a un aventa actualmente.");
            }
            else
            {
                Product productDelete = await _genericRepository.DeleteAsync(product);
                productDelete.Category = await _categoryRepository.FindCategoryByIdAsync(productDelete.CategoryId);

                productResponse = _mapper.Map<ProductResponse>(productDelete);
            }
            _logger.LogInformation("Out - DeleteProductAsync");
            return productResponse;
        }
    }
}
