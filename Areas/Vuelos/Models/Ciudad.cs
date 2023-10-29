namespace MVC_ProyectoFinal.Areas.Vuelos.Models
{
    public class Ciudad
    {
        private int _id;
        private string _nombre;

        public Ciudad()
        {
            _id = 0;
            _nombre = "default";
        }

        public Ciudad(int id, string nombre)
        {
            _id = id;
            _nombre = nombre;

        }

        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}
