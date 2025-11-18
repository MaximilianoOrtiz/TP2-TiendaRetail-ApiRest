using Application.Interfaces.Repository;
using Application.Interfaces.Service;
using Application.ServiceImpl;
using Application.UseCase;
using Infraestructure;
using Infraestructure.Commands;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
                options.AddPolicy("PolicyCors", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
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

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();

                    // 🔹 Aplica migraciones pendientes (si las hay)
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Error al aplicar las migraciones o inicializar la base de datos.");
                }
            }

            // Habilitar CORS en la aplicación
            //app.UseCors(MyAllowSpecificOrigins);
            app.UseCors("PolicyCors");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseCors("PolicyCors");
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
