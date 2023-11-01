using System.ComponentModel.DataAnnotations;

namespace MVC_ProyectoFinal.Areas.Flights.Models.Passengers
{
    public class Younger : Passenger
    {
        private int _adultYounger;

        public Younger() { }
        public Younger(int id, string firstName, string lastName, bool gender,
            DateTime birthDay, int type) : base(id, firstName, lastName, gender, birthDay, type)
        {
            _adultYounger = -1; 
        }
        public Younger(int id, string firstName, string lastName, bool gender,
           DateTime birthDay, int type, int adult) : base(id, firstName, lastName, gender, birthDay, type)
        {
            _adultYounger = adult;
        }

        [Required]
        public int AdultYounger { get => _adultYounger; set => _adultYounger = value; }
    }
}
