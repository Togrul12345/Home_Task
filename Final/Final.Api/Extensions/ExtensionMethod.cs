using Final.Bl.Profiles;
using Final.Bl.Services.Concretes;
using Final.Bl.Services.Interfaces;
using Final.Bl.Validators;
using Final.Core;
using Final.Data.Contexts;
using Final.Data.GenericRepositories.Abstractions;
using Final.Data.GenericRepositories.Implementations;
using Final.Data.Repositories.Abstractions;
using Final.Data.Repositories.Implementations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using System.Text;

namespace Final.Api.Extensions
{
    public static  class ExtensionMethod
    {
      
       
        public static void AddService(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(typeof(CreateCategoryDtoValidator).Assembly);
            services.AddDbContext<FinalAppDbContext>(opt =>
            {
                opt.UseSqlServer("Server=DESKTOP-MFDQNKF\\SQLEXPRESS;Database=FinalAppDB;Trusted_Connection=True;TrustServerCertificate=True");
            });
            services.AddIdentity<AppUser, IdentityRole>(opt =>
             {
                 opt.Password.RequiredLength = 8;
                 opt.User.RequireUniqueEmail = true;
                 opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";

             }).AddEntityFrameworkStores<FinalAppDbContext>().AddDefaultTokenProviders();
           

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISizeService, SizeService>();

            services.AddAutoMapper(typeof(CategoryProfile));
            services.AddAutoMapper(typeof(ProductProfile));
            services.AddAutoMapper(typeof(ColorProfile));
            services.AddAutoMapper(typeof(SizeProfile));
        }
    }


}



        