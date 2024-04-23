using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Infraestructure;

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
            });

            //Custom
            var connectionString = builder.Configuration["ConnectionString"];
            builder.Services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));

            var app = builder.Build();

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
