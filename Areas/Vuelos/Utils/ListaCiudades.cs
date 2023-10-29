using MVC_ProyectoFinal.Areas.Vuelos.Models;

namespace MVC_ProyectoFinal.Areas.Vuelos.Utils
{
    public class ListaCiudades
    {
        private static ListaCiudades? _instancia;
        private List<Ciudad>? _ciudades;
        private ListaCiudades()
        {
            _ciudades = new List<Ciudad>
            {
                new Ciudad(0,"Quito"),
                new Ciudad(1,"Guayaquil"),
                new Ciudad(2,"Cuenca"),
                new Ciudad(3,"Manta"),
                new Ciudad(4,"Galápagos"),
                new Ciudad(5,"Esmeraldas"),
                new Ciudad(6,"Loja"),
            };
        }

        public List<Ciudad>? Ciudades { get => _ciudades; set => _ciudades = value; }
        public static ListaCiudades Instancia()
        {
            if (_instancia == null) { _instancia = new ListaCiudades (); }
            return _instancia;
        }
    }
}
