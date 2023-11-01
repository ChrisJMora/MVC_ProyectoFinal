using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ProyectoFinal.Areas.Flights.Models.Catalogues
{
    public class Flight
    {
        private string _idFlight;

        private int _airlineFlight;             // Airline Catalogue
        private int _originFlight;              // City Catalogue
        private int _destinationFlight;         // City Catalogue
        private int _gateFlight;                // Gate Catalogue

        private DateTime _departureDateFlight;  // dd//mm//aa
        private DateTime _arrivalDateFlight;    // dd//mm//aa

        private TimeSpan _departureTimeFlight;  // hh//mm//ss
        private TimeSpan _arrivalTimeFlight;    // hh//mm//ss

        private int _seatsAvailFlight;
        private int _prefSeatsAvailFlight;      // 10% of the seats available
        private double _priceFlight;
        private double _prefPriceFlight;        // 50% more than the normal price

        public Flight() { }
        public Flight(string id, int airline, int origin, int destination, int gate,
            DateTime departureDate, DateTime arrivalDate, TimeSpan departureTime,
            TimeSpan arrivalTime, int seatsAvail, int prefSeatsAvail, double price, double prefPrice)
        {
            _idFlight = id;
            _airlineFlight = airline;
            _originFlight = origin;
            _destinationFlight = destination;
            _gateFlight = gate;
            _departureDateFlight = departureDate;
            _arrivalDateFlight = arrivalDate;
            _departureTimeFlight = departureTime;
            _arrivalTimeFlight = arrivalTime;
            _seatsAvailFlight = seatsAvail;
            _prefSeatsAvailFlight = prefSeatsAvail;
            _priceFlight = price;
            _prefPriceFlight = prefPrice;

        }

        public double GetPriceAdult(bool classRsvFlight)
        {
            if (classRsvFlight) { return _priceFlight; }
            return _prefPriceFlight;
        }
        public double GetPriceYounger(bool classRsvFlight)
        {
            if (classRsvFlight) { return (_priceFlight - _priceFlight * 0.5); }
            return (_prefPriceFlight - _prefPriceFlight * 0.5);
        }
        public string GetTimeFlight()
        {
            return (_arrivalTimeFlight - _departureTimeFlight).ToString(@"hh\h" + @"mm\m");
        }
        public override string ToString()
        {
            return $"""
                ______________________________________________________________________________________________
                FLIGHT DETAILS:
                    Id: {_idFlight}
                    Airline: {_airlineFlight}
                    Origin: {_originFlight} -> Destination: {_destinationFlight}
                    Gate: {_gateFlight}
                    Departure date: {DepartureDateFlight}  Arrival date: {_arrivalDateFlight}
                    Departure time: {_departureTimeFlight}  Arrival time: {_arrivalTimeFlight}
                    Seats available: {_seatsAvailFlight}    Preference seats available: {_prefSeatsAvailFlight}
                    Price: {_priceFlight}                   Preference price: {_prefPriceFlight}
                _______________________________________________________________________________________________
                """;
        }

        [Key]
        public string IdFlight { get => _idFlight; set => _idFlight = value; }
        [Required]
        public int AirlineFlight { get => _airlineFlight; set => _airlineFlight = value; }
        [Required]
        public int OriginFlight { get => _originFlight; set => _originFlight = value; }
        [Required]
        public int DestinationFlight { get => _destinationFlight; set => _destinationFlight = value; }
        [Required]
        public int GateFlight { get => _gateFlight; set => _gateFlight = value; }
        public int DayDepartureFlight { get => DepartureDateFlight.Day; }
        public int MonthDepartureFlight { get => DepartureDateFlight.Month; }
        public int YearDepartureFlight { get => DepartureDateFlight.Year; }
        public int DayArrivalFlight { get => _arrivalDateFlight.Day; }
        public int MontArrivalFlight { get => _arrivalDateFlight.Month; }
        public int YearArrivalFlight { get => _arrivalDateFlight.Year; }
        public int HourDepartureFlight { get => _departureTimeFlight.Hours; }
        public int MinuteDepartureFlight { get => _departureTimeFlight.Minutes; }
        public int HourArrivalFlight { get => _arrivalTimeFlight.Hours; }
        public int MinuteArrivalFlight { get => _arrivalTimeFlight.Minutes; }
        [Required]
        public int SeatsAvailFlight { get => _seatsAvailFlight; set => _seatsAvailFlight = value; }
        public int PrefSeatsAvailFlight { get => _prefSeatsAvailFlight; set => _prefSeatsAvailFlight = value; }
        [Required]
        public double PriceFlight { get => _priceFlight; set => _priceFlight = value; }
        public double PrefPriceFlight { get => _prefPriceFlight; set => _prefPriceFlight = value; }
        public DateTime DepartureDateFlight { get => _departureDateFlight; set => _departureDateFlight = value; }
        public DateTime ArrivalDateFlight { get => _arrivalDateFlight; set => _arrivalDateFlight = value; }
        public TimeSpan DepartureTimeFlight { get => _departureTimeFlight; set => _departureTimeFlight = value; }
        public TimeSpan ArrivalTimeFlight { get => _arrivalTimeFlight; set => _arrivalTimeFlight = value; }
    }
}

