using MVC_ProyectoFinal.Areas.Vuelos.Models.Pasajeros;

namespace MVC_ProyectoFinal.Areas.Vuelos.Models
{
    public class Solicitud
    {
        private List<Pasajero>? _acompaniantes;
        private int _destino;
        private DateOnly _fSalida;
        private int _id;
        private int _origen;


        public Solicitud()
        {
            _id = 0;
            _origen = 0;
            _destino = 0;
            _fSalida = new DateOnly();
            _acompaniantes = new List<Pasajero>();
        }

        public Pasajero? siguiente()
        {
            if (_id == _acompaniantes?.Count) { return null; }
            Pasajero? pasajero = _acompaniantes?[_id];
            _id++;
            return pasajero;
        }

        public void initAcompaniantes(int Adultos, int Ninios, int Infantes)
        {
            if (_acompaniantes != null)
            {
                for (int i = 0; i < Adultos; i++)
                {
                    Console.WriteLine("Se añade un Adulto");
                    Adulto adulto = new Adulto();
                    adulto.Id = _acompaniantes.Count;
                    _acompaniantes.Add(adulto);
                }
                for (int i = 0; i < Ninios; i++)
                {
                    Console.WriteLine("Se añade un Niño");
                    MenorEdad menorEdad = new MenorEdad(true);
                    menorEdad.Id = _acompaniantes.Count;
                    _acompaniantes.Add(menorEdad);
                }
                for (int i = 0; i < Infantes; i++)
                {

                    Console.WriteLine("Se añade un Infante");
                    MenorEdad menorEdad = new MenorEdad(false);
                    menorEdad.Id = _acompaniantes.Count;
                    _acompaniantes.Add(menorEdad);
                }
            }
        }

        public List<Pasajero> obtnRepresentantes()
        {
            List<Pasajero> representantes = new List<Pasajero>();
            foreach (Pasajero pasajero in _acompaniantes)
            {
                if (pasajero is Adulto)
                {
                    representantes.Add(pasajero);
                }
            }
            return representantes;
        }

        public Pasajero obtnPasajero(int id)
        {
            return _acompaniantes[id];
        }

        public bool verificarViaje(int Origen, int Destino)
        {
            return Origen == Destino;
        }

        public int obtnNumAdultos()
        {
            if (_acompaniantes == null) { return 0;  }

            int total = 0;
            foreach (Pasajero pasajero in _acompaniantes)
            {   
                if ( pasajero is Adulto)
                {
                    total += 1;
                }
            }
            return total;
        }

        public int obtnNumNinios()
        {
            if (_acompaniantes == null) { return 0; }

            int total = 0;
            foreach (Pasajero pasajero in _acompaniantes)
            {
                if (pasajero is MenorEdad)
                {
                    MenorEdad menorEdad = (MenorEdad) pasajero;
                    if (menorEdad.Tipo)
                    {
                        total += 1;
                    }
                }
            }
            return total;
        }

        public int obtnNumInfantes()
        {
            if (_acompaniantes == null) { return 0; }

            int total = 0;
            foreach (Pasajero pasajero in _acompaniantes)
            {
                if (pasajero is MenorEdad)
                {
                    MenorEdad menorEdad = (MenorEdad)pasajero;
                    if (!menorEdad.Tipo)
                    {
                        total += 1;
                    }
                }
            }
            return total;
        }

        public List<Pasajero>? Acompaniantes { get => _acompaniantes; set => _acompaniantes = value; }
        public int Destino { get => _destino; set => _destino = value; }
        public DateOnly FSalida { get => _fSalida; set => _fSalida = value; }
        public int Id { get => _id; set => _id = value; }
        public int Origen { get => _origen; set => _origen = value; }
    }
}
