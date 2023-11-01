using Microsoft.AspNetCore.Mvc;
using MVC_ProyectoFinal.API_Service;
using MVC_ProyectoFinal.Areas.Flights.Models.Catalogues;
using MVC_ProyectoFinal.Areas.Flights.Models.Control;
using MVC_ProyectoFinal.Areas.Flights.Models.Passengers;

namespace MVC_ProyectoFinal.Areas.Flights.Controllers
{
    [Area("Flights")]
    public class FlightController : Controller
    {
        public IActionResult FormFlight()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FormFlight(int Origin, int Destination, DateTime DepartureDate,
            List<int> numOfPassengers)
        {
            await PassengerControl.Instance().AddPassengers(numOfPassengers);
            FlightControl.Instance().OriginFlight = Origin;
            FlightControl.Instance().DestinationFlight = Destination;
            FlightControl.Instance().DepartureDateFlight = DepartureDate;
            return RedirectToAction("FlightCatalogue");
        }

        public async Task<IActionResult> FlightCatalogue()
        {
            List<Flight>? availableFlights = await FlightControl.Instance().availableFlights();
            if (availableFlights == null ) { return View(); }
            return View(availableFlights);
        }

        public async Task<IActionResult> FlightDetails(string IdFlight, bool Class)
        {
            Console.WriteLine($"""
                _____________________
                [FLightDetails]
                IdFlight: {IdFlight}
                Class: {Class}
                ---------------------
                """);
            FlightControl.Instance().ClassFlight = Class;
            Flight? flight = await API_Service<Flight>.Instance().Get(IdFlight);
            if (flight == null) { return View(); }
            Console.WriteLine(flight.ToString());
            return View(flight);
        }

        public IActionResult FormPassenger()
        {
            PassengerType? type = PassengerControl.Instance().NextPassengerType();
            if (type == null) { return RedirectToAction("PassengerInfo"); }
            if (type.ViewPassengerType) { return RedirectToAction("CreateAdult"); }
            return RedirectToAction("CreateYounger",new { IdPassengerType = type.IdPassangerType });
        }

        public IActionResult CreateAdult()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdult(string FirstName, string LastName, DateTime BirthDay,
            bool Gender, string Email, string Phone)
        {
            Adult adult = new Adult()
            {
                IdPassenger = 0,
                FirstNamePassenger = FirstName,
                LastNamePassenger = LastName,
                BirthDatePassenger = BirthDay,
                TypePassenger = 1,
                GenderPassenger = Gender,
                EmailAdult = Email,
                PhoneAdult = Phone
            };
            Console.WriteLine($"""
                [CreateAdult]
                {adult}
                Email: {Email}
                Phone: {Phone}
                """);
            bool answer = await API_Service<Adult>.Instance().Post(adult);
            Console.WriteLine($"Answer post: {answer}");
            return RedirectToAction("FormPassenger");
        }

        public async Task<IActionResult> EditAdult(int IdPassenger)
        {
            Console.WriteLine($"""
                [EditAdult]
                {IdPassenger}
                """);
            Adult? passenger = await API_Service<Adult>.Instance().Get(IdPassenger);
            if (passenger == null) { return RedirectToAction("PassengerInfo"); }
            Console.WriteLine($"""
                {passenger}
                """);
            return View(passenger);
        }

        [HttpPost]
        public async Task<IActionResult> EditAdult(int IdPassenger, string FirstName, string LastName, DateTime BirthDay,
            bool Gender, string Email, string Phone)
        {
            Adult adult = new Adult()
            {
                IdPassenger = IdPassenger,
                FirstNamePassenger = FirstName,
                LastNamePassenger = LastName,
                BirthDatePassenger = BirthDay,
                TypePassenger = 1,
                GenderPassenger = Gender,
                EmailAdult = Email,
                PhoneAdult = Phone
            };

            Console.WriteLine($"""
                [EditAdult HttpPost]
                IdPassenger: {IdPassenger}
                {adult}
                Email: {Email}
                Phone: {Phone}
                """);
            bool answer = await API_Service<Adult>.Instance().Put(IdPassenger, adult);
            Console.WriteLine($"Answer post: {answer}");
            return RedirectToAction("PassengerInfo");
        }

        public IActionResult CreateYounger(int IdPassengerType)
        {
            Console.WriteLine($"[CreateYounger] IdPassengerType: {IdPassengerType}");
            return View(IdPassengerType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateYounger(string FirstName, string LastName, DateTime BirthDay,
            bool Gender, int Adult, int Type)
        {
            Younger younger = new Younger()
            {
                IdPassenger = 0,
                FirstNamePassenger = FirstName,
                LastNamePassenger = LastName,
                BirthDatePassenger = BirthDay,
                TypePassenger = Type,
                GenderPassenger = Gender,
                AdultYounger = Adult
            };
            Console.WriteLine($"""
                [CreateAdult]
                {younger}
                Adult: {Adult}
                """);
            await API_Service<Younger>.Instance().Post(younger);
            return RedirectToAction("FormPassenger");
        }

        public async Task<IActionResult> EditYounger(int IdPassenger)
        {
            Console.WriteLine($"""
                [EditYounger]
                {IdPassenger}
                """);
            Younger? passenger = await API_Service<Younger>.Instance().Get(IdPassenger);
            if (passenger == null) { return RedirectToAction("PassengerInfo"); }
            Console.WriteLine($"""
                {passenger}
                """);
            return View(passenger);
        }

        [HttpPost]
        public async Task<IActionResult> EditYounger(int IdPassenger, int Type, string FirstName,
            string LastName, DateTime BirthDay, bool Gender, int Adult)
        {
            Younger younger = new Younger()
            {
                IdPassenger = IdPassenger,
                FirstNamePassenger = FirstName,
                LastNamePassenger = LastName,
                BirthDatePassenger = BirthDay,
                TypePassenger = Type,
                GenderPassenger = Gender,
                AdultYounger = Adult
            };

            Console.WriteLine($"""
                [EditYounger HttpPost]
                IdPassenger: {IdPassenger}
                {younger}
                Younger: {Adult}
                """);
            bool answer = await API_Service<Younger>.Instance().Put(IdPassenger, younger);
            Console.WriteLine($"Answer post: {answer}");
            return RedirectToAction("PassengerInfo");
        }

        public async Task<IActionResult> PassengerInfo()
        {
            List<Passenger>? passengers = await API_Service<Passenger>.Instance().Get();
            if (passengers == null) { return View(); }
            return View(passengers);
        }

    }
}
