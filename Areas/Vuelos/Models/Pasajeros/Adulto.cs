namespace MVC_ProyectoFinal.Areas.Vuelos.Models.Pasajeros
{
    public class Adulto : Pasajero
    {
        private string _telefono;
        private string _mail;

        public Adulto()
        {
            _telefono = string.Empty;
            _mail = string.Empty;
        }

        public Adulto(string telefono, string mail)
        {
            _telefono = telefono;
            _mail = mail;
        }

        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Mail { get => _mail; set => _mail = value; }
    }
}
