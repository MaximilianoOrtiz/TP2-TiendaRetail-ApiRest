using Application.ConfigMapper;
using Application.Interfaces;
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
            var builder = WebApplication.CreateBuilder(args);

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
            var connectionString = builder.Configuration["ConnectionString"];
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

            //Custom Inyection Dependency
            builder.Services.AddTransient<IProductService, ProductServiceImpl>();
            builder.Services.AddTransient<IProductRepository, ProductRepositoryImpl>();

            builder.Services.AddTransient<ICategoryService, CategorySeriviceImpl>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepositoryImpl>();

            builder.Services.AddTransient<IGenericRepository, GenericRepositoryImpl>();




            //Config Automapper
            builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("get/", () => "Hello World!");



            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
