
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.Models;
using PurpleBuzzTask.Services.Concretes;
using PurpleBuzzTask.Services.Interfaces;
using ServiceForService = PurpleBuzzTask.Services.Concretes.ServiceForService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IServiceForService, ServiceForService>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));
builder.Services.AddIdentity<AppUser,IdentityRole>(opt =>
{
    opt.Password.RequireNonAlphanumeric = false;
    // Default Lockout settings.
    opt.Password.RequiredLength = 4;
    opt.Password.RequireUppercase = true;
    //opt.Password.RequiredUniqueChars = 2;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();

app.MapControllerRoute(
   name: "Admin",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
 );
app.MapControllerRoute(name: "Default", pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();
