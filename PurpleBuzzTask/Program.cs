
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzTask.DAL;
using PurpleBuzzTask.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSql")));
builder.Services.AddIdentity<AppUser,IdentityRole>(opt =>
{
    // Default Lockout settings.
    opt.Password.RequiredLength = 4;
    opt.Password.RequireUppercase = true;
    opt.Password.RequiredUniqueChars = 2;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();



var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
   name: "Dashboard",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
 );

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{Id?}");

app.Run();
