using MVC_ProyectoFinal.API_Service;
using MVC_ProyectoFinal.Areas.Flights.Models.Passengers;

namespace MVC_ProyectoFinal.Areas.Flights.Models.Control
{
    public class PassengerControl
    {
        private Dictionary<PassengerType, int> _passengers;
        private static PassengerControl? _instance;

        private PassengerControl() 
        {
            Console.WriteLine("Instance of Passenger Control !!!");
            _passengers = new Dictionary<PassengerType, int>(); 
        }

        public async Task<string?> GetTypePassenger(int type)
        {
            List<PassengerType>? passengerTypes = await API_Service<PassengerType>.Instance().Get();
            if (passengerTypes == null ) { return null; }
            PassengerType? passengerType = passengerTypes.Find(x => x.IdPassangerType == type);
            if (passengerType == null) { return null; }
            return passengerType.NamePassengerType;
        }

        public async Task AddPassengers(List<int> numPassengers)
        {
            List<PassengerType>? passengersType = await API_Service<PassengerType>.Instance().Get();
            if (passengersType == null) { return; }
            _passengers = new Dictionary<PassengerType, int>();
            Console.WriteLine($""""
                ____________________________________________________
                [AddPassengers]
                PassengerType list: {passengersType.Count} elements
                NumOfPassengers list: {numPassengers.Count} elements
                ----------------------------------------------------
                """");
            for (int i = 0; i < numPassengers.Count; i++)
            {
                if (!_passengers.TryGetValue(passengersType[i], out var passenger))
                {
                    _passengers.Add(passengersType[i], numPassengers[i]);
                }
                else { Console.WriteLine("clave duplicada"); }
            }
            Console.WriteLine($"""
                NumElements in Dictionary: {_passengers.Count}
                ----------------------------------------------------
                """);
            foreach ((PassengerType key, int value) in _passengers)
            {
                Console.WriteLine($"""
                        NamePassengerType: {key.NamePassengerType},
                        IdPassengerType: {key.IdPassangerType},
                        NumOfPassengers: {value}
                    """);
            }
        }
        public PassengerType? NextPassengerType()
        {
            foreach (var item in _passengers)
            {
                if (item.Value != 0)
                {
                    _passengers[item.Key]--;
                    return item.Key;
                }
            }
            return null;
        }
        public async Task<List<Adult>?> GetAdults()
        {
            return await API_Service<Adult>.Instance().Get();
        }
        public static PassengerControl Instance()
        {
            if (_instance == null) { _instance = new PassengerControl(); }
            return _instance;
        }
        public double GetPrice(PassengerType type, double price)
        {
            Console.WriteLine($"""
                ______________
                [GetPrice]
                Type: {type.IdPassangerType}
                Price: {price}
                --------------
                """);
            int numberOfPassenger = _passengers[type];
            return price * numberOfPassenger;
        }
    }
}
