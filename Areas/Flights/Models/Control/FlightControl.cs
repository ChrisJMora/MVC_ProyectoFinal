using Microsoft.CodeAnalysis.CSharp.Syntax;
using MVC_ProyectoFinal.API_Service;
using MVC_ProyectoFinal.Areas.Flights.Models.Catalogues;
using MVC_ProyectoFinal.Areas.Flights.Models.Passengers;

namespace MVC_ProyectoFinal.Areas.Flights.Models.Control
{
    public class FlightControl
    {
        // Request
        private int _originFlight;              // City Catalogue
        private int _destinationFlight;         // City Catalogue
        private DateTime _departureDateFlight;  // dd//mm//aa
        private bool _classFlight;             // True: Economic / False: Preference

        private static FlightControl? _instance;

        public FlightControl()
        {
            _originFlight = -1;
            _destinationFlight = -1;
            _departureDateFlight = new DateTime();
            ClassFlight = true;
        }

        public int OriginFlight { get => _originFlight; set => _originFlight = value; }
        public int DestinationFlight { get => _destinationFlight; set => _destinationFlight = value; }
        public DateTime DepartureDateFlight { get => _departureDateFlight; set => _departureDateFlight = value; }
        public bool ClassFlight { get => _classFlight; set => _classFlight = value; }

        public double GetPrice(Flight flight, PassengerType type)
        {
            if (type.IdPassangerType == 1) { return flight.GetPriceAdult(_classFlight); }
            if (type.IdPassangerType == 2 || type.IdPassangerType == 3) { return flight.GetPriceYounger(_classFlight); }
            return 0;
        }
        public async Task<List<Flight>?> availableFlights()
        {
            List<Flight>? list = await API_Service<Flight>.Instance().Get();
            if (list == null) { return null; }
            return list.FindAll(x => 
                   x.OriginFlight == OriginFlight
                && x.DestinationFlight == DestinationFlight 
                && x.DepartureDateFlight == DepartureDateFlight);
        }
        public async Task<string?> GetAirlane(int idAirlane)
        {
            List<Airline>? airlines = await API_Service<Airline>.Instance().Get();
            if (airlines == null) { return null; }
            Console.WriteLine($"Airlines: {airlines.Count}");
            Airline? airline = airlines.Find(x => x.IdAirline == idAirlane);
            if (airline == null) { return null; }
            Console.WriteLine($"Airline: {airline.NameAirline}");
            return airline.NameAirline;
        }
        public async Task<string?> GetCity(int idCity)
        {
            List<City>? cities = await API_Service<City>.Instance().Get();
            if (cities == null) { return null; }
            City? city = cities.Find(x => x.IdCity == idCity);
            if (city == null) { return null; }
            return city.NameCity;
        }
        public static FlightControl Instance()
        {
            if (_instance == null) { return _instance = new FlightControl(); }
            return _instance;
        }

    }
}
