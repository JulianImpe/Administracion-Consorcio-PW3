using Administracion_Consorcio_PW3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar MVC
builder.Services.AddControllersWithViews();

// Registrar el DbContext
var connectionString = builder.Configuration.GetConnectionString("ConsorcioDB");
builder.Services.AddDbContext<ConsorcioDbContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();

// Configuración básica
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();