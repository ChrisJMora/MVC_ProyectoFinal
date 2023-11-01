using MVC_ProyectoFinal.Areas.Flights.Models.Passengers;

namespace MVC_ProyectoFinal.Areas.Flights.Utils
{
    public class ListaPasajeros
    {
        private static ListaPasajeros? _instancia;
        private List<Passenger>? _pasajeros;
        private ListaPasajeros()
        {
            _pasajeros = new List<Passenger>
            {

            };
        }

        public List<Passenger>? Pasajeros { get => _pasajeros; set => _pasajeros = value; }
        public static ListaPasajeros Instancia()
        {
            if (_instancia == null) { _instancia = new ListaPasajeros(); }
            return _instancia;
        }
    }
}
