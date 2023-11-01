using System.ComponentModel.DataAnnotations;

namespace MVC_ProyectoFinal.Areas.Flights.Models.Passengers
{
    public class Adult : Passenger
    {
        private string _phoneAdult;
        private string _emailAdult;

        public Adult() { }
        public Adult(int id, string firstName, string lastName, bool gender,
            DateTime birthDay, string phoneAdult, string emailAdult) :
            base(id, firstName, lastName, gender, birthDay, 1)
        {
            _phoneAdult = phoneAdult;
            _emailAdult = emailAdult;
        }

        [Required]
        public string PhoneAdult { get => _phoneAdult; set => _phoneAdult = value; }
        [Required]
        public string EmailAdult { get => _emailAdult; set => _emailAdult = value; }
    }
}
