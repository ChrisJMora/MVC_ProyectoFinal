using MVC_ProyectoFinal.Areas.Vuelos.Models;

namespace MVC_ProyectoFinal.Areas.Vuelos.Utils
{
    public class ListaAerolineas
    {
        private static ListaAerolineas? _instancia;
        private List<Aerolinea> _listaAerolineas = new List<Aerolinea>();
        private ListaAerolineas()
        {
            _listaAerolineas = new List<Aerolinea>()
            {
                new Aerolinea(0,"Latam Airlines"),
                new Aerolinea(1,"Avianca Airlines"),
                new Aerolinea(2,"Tame Airlines"),
                new Aerolinea(3,"Copa Airlines"),
                new Aerolinea(4,"AEROMEXICO"),
            };
        }

        public List<Aerolinea> Aerolineas { get => _listaAerolineas; }
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
