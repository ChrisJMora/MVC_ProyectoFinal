using MVC_ProyectoFinal.Areas.Flights.Models.Catalogues;

namespace MVC_ProyectoFinal.Areas.Flights.Utils
{
    public class ListaCiudades
    {
        private static ListaCiudades? _instancia;
        private List<City>? _ciudades;
        private ListaCiudades()
        {
            _ciudades = new List<City>
            {
                new City(0,"Quito"),
                new City(1,"Guayaquil"),
                new City(2,"Cuenca"),
                new City(3,"Manta"),
                new City(4,"Galápagos"),
                new City(5,"Esmeraldas"),
                new City(6,"Loja"),
            };
        }

        public List<City>? Ciudades { get => _ciudades; set => _ciudades = value; }
        public static ListaCiudades Instancia()
        {
            if (_instancia == null) { _instancia = new ListaCiudades (); }
            return _instancia;
        }
    }
}
