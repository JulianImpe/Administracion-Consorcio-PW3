using Administracion_Consorcio_PW3.Models;
using Administracion_Consorcio_PW3.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUnidadService, UnidadService>();

var connectionString = builder.Configuration.GetConnectionString("ConsorcioDB");
builder.Services.AddDbContext<ConsorcioDbContext>(options =>
    options.UseSqlServer(connectionString)
);

var app = builder.Build();
app.UseSession();
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