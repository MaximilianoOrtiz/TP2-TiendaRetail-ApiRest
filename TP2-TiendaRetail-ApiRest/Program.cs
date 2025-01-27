using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Application.ServiceImpl;
using Application.UseCase;
using Infraestructure;
using Infraestructure.Commands;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace TP2_TiendaRetail_ApiRest
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://127.0.0.1:5501"); // add the allowed origins  
                                  });
            });

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Logging.AddLog4Net();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                //options.EnableAnnotations();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "TP2 - Tienda Retail - API",
                    Description = "Proyecto Software",
                    Contact = new OpenApiContact
                    {
                        Name = "Maximiliano Ortiz",
                    }
                });

                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });


            //Inyection DbContext
            var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING") ?? builder.Configuration["ConnectionString"];
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

            //Custom Inyection Dependency
            builder.Services.AddTransient<IProductService, ProductServiceImpl>();
            builder.Services.AddTransient<IProductRepository, ProductRepositoryImpl>();

            builder.Services.AddTransient<ICategoryService, CategoryServiceImpl>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepositoryImpl>();

            builder.Services.AddTransient<IGenericRepository, GenericRepositoryImpl>();

            builder.Services.AddTransient<ISaleProductRepository, SaleProductRepositoryImpl>();
            builder.Services.AddTransient<ISaleProductService, SaleProductServiceImpl>();

            builder.Services.AddTransient<ISaleService, SaleServiceImpl>();

            builder.Services.AddTransient<ICalculatorService, CalculatorServiceImpl>();

            builder.Services.AddTransient<IParametryRepository, ParametryRepositoryImpl>();

            builder.Services.AddTransient<ISaleRepository, SaleRepositoryImpl>();







            // Assembly.GetExecutingAssembly()
            //Config Automapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            // builder.Services.AddAutoMapper()

            var app = builder.Build();

            // Habilitar CORS en la aplicación
            app.UseCors(MyAllowSpecificOrigins);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
