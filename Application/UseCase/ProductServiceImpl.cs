using Application.Dtos;
using Application.Dtos.Product;
using Application.Interfaces;
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

        public ProductServiceImpl(
            IProductRepository repository,
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

        public async Task<List<ProductoGetResponse>> findProductbyCategoryIdAndName(int[] categorys, string name, int limit, int offSet)
        {
            _logger.LogInformation("Init - find Product by categoryId and name");
            _logger.LogInformation("Datos de entrada --> Category.Length: " + categorys.Length
                + " name: " + name
                + " limit: " + limit
                + " offSet: " + offSet);

            List<Product> listProducts = new List<Product>();
            List<ProductoGetResponse> response = new List<ProductoGetResponse>();

            if (categorys.Length > 0)
            {
                foreach (int category in categorys)
                {
                    listProducts = listProducts.Concat(
                        await _productRepository.findProductByCategoryIdAndName(category, name)).ToList();
                }
                _logger.LogInformation($"Cantidad de productos encontrados por todas las categorias ingresadas: {listProducts.Count}");
            }
            else
            {
                if (name != null && name != "")
                {
                    listProducts = await _productRepository.findProductByName(name);
                }
                _logger.LogInformation($"Cantidad de productos encontrados por nombre ingresado: {listProducts.Count}");
            }

            _logger.LogInformation("Inicio paginación");
            List<Product> productsTemp = new List<Product>();
            productsTemp = listProducts.Skip(offSet).Take(limit).ToList();

            _logger.LogInformation($"Total de productos paginados: {productsTemp.Count}");
            foreach (Product item in productsTemp)
            {
                _logger.LogInformation($"Nombre: {item.Name} Categoria ID: {item.categoryId}");
            }

            //Realizo el mapeo 
            foreach (Product product in productsTemp)
            {
                response.Add(_mapper.Map<ProductoGetResponse>(product));
            }
            _logger.LogInformation("Out - find Product by categoryId and name");
            return response;
        }

        public async Task<ProductResponse> saveProduct(ProductRequest productRequest)
        {
            _logger.LogInformation("Init - saveProduct");
            Category category = await _categoryRepository.findCateegoryById(productRequest.CategoryId);
            Product product = new Product();

            product = _mapper.Map<Product>(productRequest);
            product.Category = category;

            _logger.LogInformation("Out - saveProduct");
            return _mapper.Map<ProductResponse>(await _genericRepository.save(product));
        }

        public async Task<bool> existProductByEqualName(string name)
        {
            Product product = await _productRepository.findProductByEqualName(name);
            if (product == null)
            {
                return false;
            }
            return true;
        }

        public async Task<ProductResponse> findProductbyId(Guid productoId)
        {
            return _mapper.Map<ProductResponse>(await _productRepository.findProductbyId(productoId));
        }
    }

}
