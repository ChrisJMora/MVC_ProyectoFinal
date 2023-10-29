using MVC_ProyectoFinal.Areas.Vuelos.Models;

namespace MVC_ProyectoFinal.Areas.Vuelos.Utils
{
    public class BDsolicitud
    {
        private static BDsolicitud? _instancia;
        private Solicitud? _solicitud;
        private BDsolicitud()
        {
            _solicitud = new Solicitud();
        }

        public Solicitud? Solicitud { get => _solicitud; set => _solicitud = value; }
        public static BDsolicitud Instancia()
        {
            if (_instancia == null) { _instancia = new BDsolicitud (); }
            return _instancia;
        }
    }
}
