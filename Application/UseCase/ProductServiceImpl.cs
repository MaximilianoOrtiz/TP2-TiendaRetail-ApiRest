using Application.Dtos;
using Application.Dtos.Product;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.ICategory;
using Application.Interfaces.IProduct;
using Application.Interfaces.ISalesProducts;
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

        public ProductServiceImpl(
            IProductRepository repository,
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
            Category category = await _categoryRepository.findCategoryById(productRequest.CategoryId);
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
            Product product = await _productRepository.findProductbyId(productoId);
            if (product == null) { return null; }
            product.Category = await _categoryRepository.findCategoryById(product.categoryId);

            return _mapper.Map<ProductResponse>(product);
        }

        public async Task<ProductResponse> updateProduct(ProductRequest productRequest, Guid productId)
        {
            _logger.LogInformation("Init - updateProduct");

            ProductResponse productResponse = new ProductResponse();
            Product productUpdate = new Product();

            Product product = await _productRepository.findProductbyId(productId);
            if (product == null)
            {
                return null;
            }
            else
            {
                //No puede existir un producto con el mismo nombre en la base de datos
                if (product.Name != productRequest.Name)
                {
                    Product productConflit = await _productRepository.findProductByEqualName(productRequest.Name);
                    if (productConflit != null)
                    {
                        throw new CustomException("Ya existe un producto con ese nombre");
                    }
                }
                product.Name = productRequest.Name;
                product.Description = productRequest.Description;
                product.categoryId = productRequest.CategoryId;
                product.Price = productRequest.Price;
                product.Discount = productRequest.Discount;
                product.UrlImage = productRequest.UrlImage;

                productUpdate = await _genericRepository.update(product);
                productUpdate.Category = await _categoryRepository.findCategoryById(productRequest.CategoryId);

                productResponse = _mapper.Map<ProductResponse>(productUpdate);
            }

            _logger.LogInformation("Out - updateProduct");
            return productResponse;
        }

        public async Task<ProductResponse> deleteProduct(Guid productId)
        {
            _logger.LogInformation("Init - deleteProduct");
            ProductResponse productResponse = new ProductResponse();
            Product product = await _productRepository.findProductbyId(productId);

            if (product == null)
            {
                return null;
            }
            if (await _saleProductRepository.hasProductAssociated(productId))
            {
                throw new CustomException("No se puede eliminar un producto que este asiciado a un aventa actualmente.");
            }
            else
            {
                Product productDelete = await _genericRepository.delete(product);
                productDelete.Category = await _categoryRepository.findCategoryById(productDelete.categoryId);

                productResponse = _mapper.Map<ProductResponse>(productDelete);
            }
            _logger.LogInformation("Out - deleteProduct");
            return productResponse;
        }
    }
}
