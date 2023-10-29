using MVC_ProyectoFinal.Areas.Vuelos.Models;

namespace MVC_ProyectoFinal.Areas.Vuelos.Utils
{
    public class ListaVuelos
    {
        private static ListaVuelos? _instancia;
        private List<Vuelo>? _vuelos;
        private ListaVuelos()
        {
            _vuelos = new List<Vuelo>();

            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();

                int aerolinea = random.Next(0,5);
                bool clase = random.Next(2) == 1;
                int destino = random.Next(0, 7);

                int dia = random.Next(1, 30);
                DateOnly fSalida = new DateOnly(2023, 10, dia);

                int hora = random.Next(1, 24);
                int minuto = random.Next(1, 59);
                TimeOnly hSalida = new TimeOnly(hora, minuto);
                TimeOnly hAbordaje = new TimeOnly(hora - 1, minuto);
                hora = random.Next(hora, 24);
                minuto = random.Next(minuto, 59);
                TimeOnly hLlegada = new TimeOnly(hora, minuto);

                int origen;
                do
                {
                    origen = random.Next(0, 7);
                } while (origen == destino);

                double precio = random.Next(50,100);
                int plzEconomicas = random.Next(1, 20);
                int plzPreferenciales = random.Next(1, 10);

                Vuelo vuelo = new Vuelo(i,aerolinea, clase, destino, fSalida,
                    hAbordaje, hSalida, hLlegada, origen, precio, plzEconomicas,
                    plzPreferenciales);

                Console.WriteLine(vuelo.ToString());
                _vuelos.Add(vuelo);
            }

        }

        public List<Vuelo>? Vuelos { get => _vuelos; set => _vuelos = value; }

        public static ListaVuelos Instancia()
        {
            if (_instancia == null) { _instancia = new ListaVuelos(); }
            return _instancia;
        }

        public List<Vuelo>? vuelosDisponibles(Solicitud? solicitud)
        {
            if (_vuelos == null || solicitud == null) { return null; }
            return _vuelos.FindAll(x => x.Origen == solicitud.Origen && 
            x.Destino == solicitud.Destino && x.FSalida == solicitud.FSalida);
        }
    }
}
