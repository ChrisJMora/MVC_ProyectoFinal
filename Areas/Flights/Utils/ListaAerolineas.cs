using MVC_ProyectoFinal.Areas.Flights.Models.Catalogues;

namespace MVC_ProyectoFinal.Areas.Flights.Utils
{
    public class ListaAerolineas
    {
        private static ListaAerolineas? _instancia;
        private List<Airline> _listaAerolineas = new List<Airline>();
        private ListaAerolineas()
        {
            _listaAerolineas = new List<Airline>()
            {
                new Airline(0,"Latam Airlines"),
                new Airline(1,"Avianca Airlines"),
                new Airline(2,"Tame Airlines"),
                new Airline(3,"Copa Airlines"),
                new Airline(4,"AEROMEXICO"),
            };
        }

        public List<Airline> Aerolineas { get => _listaAerolineas; }
        public static ListaAerolineas Instancia()
        {
            if (_instancia == null)
            {
                _instancia = new ListaAerolineas();
            }
            return _instancia;
        }

    }
}
