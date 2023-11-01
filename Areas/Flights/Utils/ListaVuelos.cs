using MVC_ProyectoFinal.Areas.Flights.Models;
using MVC_ProyectoFinal.Areas.Flights.Models.Catalogues;

namespace MVC_ProyectoFinal.Areas.Flights.Utils
{
    public class ListaVuelos
    {
        private static ListaVuelos? _instancia;
        private List<Models.Catalogues.Flight>? _vuelos;
        private ListaVuelos()
        {
            _vuelos = new List<Models.Catalogues.Flight>();

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

                Flight? vuelo = null;

                //_vuelos.Add(vuelo);
            }

        }

        public List<Models.Catalogues.Flight>? Vuelos { get => _vuelos; set => _vuelos = value; }

        public static ListaVuelos Instancia()
        {
            if (_instancia == null) { _instancia = new ListaVuelos(); }
            return _instancia;
        }

    }
}
