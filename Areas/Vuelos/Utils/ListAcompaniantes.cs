using MVC_ProyectoFinal.Areas.Vuelos.Models;

namespace MVC_ProyectoFinal.Areas.Vuelos.Utils
{
    public class ListaAcompaniantes
    {
        private static ListaAcompaniantes? _instancia;
        private List<Acompaniante>? _acompaniantes;
        private ListaAcompaniantes()
        {
            _acompaniantes = new List<Acompaniante>
            {
                new Acompaniante(0,"Adulto"),
                new Acompaniante(1,"Niño"),
                new Acompaniante(2,"Infante"),
            };
        }

        public List<Acompaniante>? Acompaniantes { get => _acompaniantes; set => _acompaniantes = value; }
        public static ListaAcompaniantes Instancia()
        {
            if (_instancia == null) { _instancia = new ListaAcompaniantes (); }
            return _instancia;
        }
    }
}
