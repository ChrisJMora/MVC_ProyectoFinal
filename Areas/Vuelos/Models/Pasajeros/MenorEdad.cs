namespace MVC_ProyectoFinal.Areas.Vuelos.Models.Pasajeros
{
    public class MenorEdad : Pasajero
    {
        private int _representante;
        private bool _tipo;
        // true: Niño ; false: Infante

        public MenorEdad(bool tipo)
        {
            _representante = 0;
            _tipo = tipo;
        }

        public MenorEdad(int representante, bool tipo)
        {
            _representante = representante;
            _tipo = tipo;
        }

        public int Representante { get => _representante; set => _representante = value; }
        public bool Tipo { get => _tipo; set => _tipo = value; }
    }
}
