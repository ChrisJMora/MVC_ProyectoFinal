using MVC_ProyectoFinal.API_Service;
using MVC_ProyectoFinal.Areas.Flights.Models.Catalogues;
using MVC_ProyectoFinal.Areas.Flights.Models.Control;
using MVC_ProyectoFinal.Areas.Flights.Models.Passengers;
using MVC_ProyectoFinal.Areas.Flights.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Utils
ListaCiudades.Instancia();
ListaVuelos.Instancia();
ListaAerolineas.Instancia();
ListaPasajeros.Instancia();
ListaPasajerosSesion.Instancia();

// Sessions
FlightControl.Instance();
PassengerControl.Instance();

// API urls
API_Service<City>.Instance()._url = "http://localhost:5256/api/City";
API_Service<Airline>.Instance()._url = "http://localhost:5256/api/Airline";
API_Service<Passenger>.Instance()._url = "http://localhost:5256/api/Passenger";
API_Service<PassengerType>.Instance()._url = "http://localhost:5256/api/PassengerType";
API_Service<Flight>.Instance()._url = "http://localhost:5256/api/Flight";
API_Service<Adult>.Instance()._url = "http://localhost:5256/api/Adult";
API_Service<Younger>.Instance()._url = "http://localhost:5256/api/Younger";


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
    name: "Flights",
    pattern: "{area:exists}/{controller=Flight}/{action=FormFlight}/{id?}") ;

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
