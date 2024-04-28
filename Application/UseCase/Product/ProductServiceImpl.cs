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
        private readonly ILogger<ProductServiceImpl> _logger;
        private readonly IMapper _mapper;

        public ProductServiceImpl(IProductRepository repository, ILogger<ProductServiceImpl> logger, IMapper mapper)
        {
            _productRepository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<ProductoGetResponse>> findProductbyCategoryIdAndName(int[] categorys, string name, int limit, int offSet)
        {
            _logger.LogInformation("Init - find Product by categoryId and name");
            List<Product> listProducts = new List<Product>();
            List<ProductoGetResponse> response = new List<ProductoGetResponse>();

            _logger.LogInformation("Datos de entrada --> Category.Length: " + categorys.Length + "Name: " + name + "limit: " + limit + "offSet: " + offSet);
            if (categorys.Length > 0)
            {
                foreach (int category in categorys)
                {
                    listProducts = listProducts.Concat(await _productRepository.findProductByCategoryIdAndName(category, name)).ToList();
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
    }
}
