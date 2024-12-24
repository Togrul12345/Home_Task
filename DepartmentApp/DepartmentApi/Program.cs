using Department.Bl.Dtos.AppUserDto;
using Department.Bl.Profiles.AppUserProfile;
using Department.Bl.Services.Abstractions;
using Department.Bl.Services.Implementations;
using Department.Core;
using Department.Data.Contexts;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<CreateAppUserValidation>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric= false;
    opt.SignIn.RequireConfirmedEmail = true;
    

}).AddDefaultTokenProviders().AddEntityFrameworkStores<DepartmentDbContext>();

builder.Services.AddDbContext<DepartmentDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Hp"));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
