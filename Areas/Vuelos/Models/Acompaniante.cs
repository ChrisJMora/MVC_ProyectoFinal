namespace MVC_ProyectoFinal.Areas.Vuelos.Models
{
    public class Acompaniante
    {
        private int _id;
        private string _tipo;

        public Acompaniante(int id, string tipo)
        {
            _id = id;
            _tipo = tipo;
        }

        public Acompaniante()
        {
            _id = 0;
            _tipo = "default";
        }

        public int Id { get => _id; set => _id = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
    }
}
