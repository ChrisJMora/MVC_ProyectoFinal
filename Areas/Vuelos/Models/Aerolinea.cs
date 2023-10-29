namespace MVC_ProyectoFinal.Areas.Vuelos.Models
{
    public class Aerolinea
    {
        private int _idAerolinea;
        private string _nombreAerolinea;
        public Aerolinea(int id, string nombre)
        {
            _idAerolinea = id;
            _nombreAerolinea = nombre;
        }

        public int IdAerolinea { get => _idAerolinea; set => _idAerolinea = value; }
        public string NombreAerolinea { get => _nombreAerolinea; set => _nombreAerolinea = value; }
    }
}
