using MVC_ProyectoFinal.Areas.Vuelos.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Utils
ListaCiudades.Instancia();
ListaAcompaniantes.Instancia();
ListaVuelos.Instancia();
BDsolicitud.Instancia();
ListaAerolineas.Instancia();

builder.Services.AddRazorPages(); // Paginas Razor

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Vuelos",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}") ;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
