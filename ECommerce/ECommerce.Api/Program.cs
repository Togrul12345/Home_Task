
using ECommerce.Bl.Profiles;
using ECommerce.Bl.Services.Abstractions;
using ECommerce.Bl.Services.Implementations;
using ECommerce.Data.Contexts;
using ECommerce.Data.GenericRepository.Abstractions;
using ECommerce.Data.GenericRepository.Implementations;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);
            builder.Services.AddDbContext<ECommerceDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Hp"));
            });
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
