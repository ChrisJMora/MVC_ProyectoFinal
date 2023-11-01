using MVC_ProyectoFinal.Areas.Flights.Models.Passengers;

namespace MVC_ProyectoFinal.Areas.Flights.Utils
{
    public class ListaPasajerosSesion
    {
        private static ListaPasajerosSesion? _instancia;
        private List<Passenger>? _pasajeros;
        private ListaPasajerosSesion()
        {
            _pasajeros = new List<Passenger>
            {

            };
        }

        public List<Passenger>? Pasajeros { get => _pasajeros; set => _pasajeros = value; }
        public static ListaPasajerosSesion Instancia()
        {
            if (_instancia == null) { _instancia = new ListaPasajerosSesion(); }
            return _instancia;
        }
    }
}
