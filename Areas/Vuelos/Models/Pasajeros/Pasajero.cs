namespace MVC_ProyectoFinal.Areas.Vuelos.Models.Pasajeros
{
    public class Pasajero
    {
        private string _apellido;
        private DateOnly _fNacimiento;
        private bool _genero;
        private int _id;
        private string _nombre;
        public Pasajero()
        {
            _id = 0;
            _nombre = "default";
            _apellido = "default";
            _fNacimiento = new DateOnly();
            _genero = false;
        }

        public override string ToString()
        {
            return $"Id: {_id}";
        }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public DateOnly FNacimiento { get => _fNacimiento; set => _fNacimiento = value; }
        public bool Genero { get => _genero; set => _genero = value; }
        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
    }
}
