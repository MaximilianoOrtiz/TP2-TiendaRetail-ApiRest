using Application.Dtos;
using Application.Dtos.Product.Response;
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
        private readonly ILogger<ProductServiceImpl> _logger;
        private readonly IMapper _mapper;

        public ProductServiceImpl(IProductRepository repository,
                                  ILogger<ProductServiceImpl> logger,
                                  IMapper mapper,
                                  IGenericRepository genericRepository,
                                  ICategoryRepository categoryRepository)
        {
            _productRepository = repository;
            _logger = logger;
            _mapper = mapper;
            _genericRepository = genericRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<ProductoGetResponse>> FindProductByCategoryIdAndNameAsync(int[] categorys, string name, int limit, int offSet)
        {
            _logger.LogInformation("Init - find Product by Category and Name");
            _logger.LogInformation("Datos de entrada --> Category.Length: " + categorys.Length
                + " Name: " + name
                + " limit: " + limit
                + " offSet: " + offSet);

            List<Product> listProducts = new List<Product>();
            List<ProductoGetResponse> response = new List<ProductoGetResponse>();

            if (categorys.Length > 0)
            {
                if (!string.IsNullOrEmpty(name))
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
                    if (categorys.Length == 1 && categorys[0] == 0)
                    {
                        listProducts = await _productRepository.FindAllProduct();
                    }
                    foreach (int category in categorys)
                    {
                        listProducts = listProducts.Concat(
                            await _productRepository.FindProductByCategoryIdAsync(category)).ToList();
                    }
                    _logger.LogInformation($"Cantidad de productos encontrados por categpriaId: {listProducts.Count}");
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(name))
                {
                    listProducts = await _productRepository.FindProductByNameAsync(name);
                    _logger.LogInformation($"Cantidad de productos encontrados por nombre ingresado: {listProducts.Count}");
                }
                else {
                    listProducts = await _productRepository.FindAllProduct();
                }
            }

            _logger.LogInformation("Inicio paginación");
            List<Product> productsTemp = new List<Product>();
            if (limit > 0)
            {
                productsTemp = listProducts.Skip(offSet).Take(limit).ToList();
            }
            else
            {
                productsTemp = listProducts;
            }

            _logger.LogInformation($"Total de productos paginados: {productsTemp.Count}");

            //Realizo el mapeo 
            foreach (Product product in productsTemp)
            {
                response.Add(_mapper.Map<ProductoGetResponse>(product));
            }
            _logger.LogInformation("Out - find Product by Category and Name");
            return response;
        }

        public async Task<ProductResponse> SaveProductAsync(ProductRequest productRequest)
        {

            _logger.LogInformation("Init - SaveProductAsync");
            Category category = await _categoryRepository.FindCategoryByIdAsync(productRequest.Category);
            Product product = new Product();
            if (category != null)
            {
                product = _mapper.Map<Product>(productRequest);
                product.Category = category;
            }
            else
            {
                throw new CustomExceptionBadRequest("No se encotro una categoria con id: " + productRequest.Category);
            }

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
                        throw new CustomExceptionBadRequest("Ya existe un producto con ese nombre");
                    }
                }

                product.Name = productRequest.Name;
                product.Description = productRequest.Description;
                product.CategoryId = productRequest.Category;
                product.Price = productRequest.Price;
                product.Discount = productRequest.Discount;
                product.ImageUrl = productRequest.ImageUrl;

                productUpdate = await _genericRepository.UpdateAsync(product);
                productUpdate.Category = await _categoryRepository.FindCategoryByIdAsync(productRequest.Category);

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

            Product productDelete = await _genericRepository.DeleteAsync(product);
            productDelete.Category = await _categoryRepository.FindCategoryByIdAsync(productDelete.CategoryId);

            productResponse = _mapper.Map<ProductResponse>(productDelete);

            _logger.LogInformation("Out - DeleteProductAsync");
            return productResponse;
        }
    }
}
