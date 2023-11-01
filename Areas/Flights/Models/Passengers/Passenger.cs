using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_ProyectoFinal.Areas.Flights.Models.Passengers
{
    public class Passenger
    {
        private int _idPassenger;
        private string _firstNamePassenger;
        private string _lastNamePassenger;
        private bool _genderPassenger;
        private DateTime _birthDatePassenger;
        private int _typePassenger;

        public Passenger() { }
        public Passenger(string firstName, string lastName, bool gender,
            DateTime birthDay, int type)
        {
            _firstNamePassenger = firstName;
            _lastNamePassenger = lastName;
            _genderPassenger = gender;
            BirthDatePassenger = birthDay;
            _typePassenger = type;
        }
        public Passenger(int id, string firstName, string lastName, bool gender,
            DateTime birthDay, int type)
        {
            _idPassenger = id;
            _firstNamePassenger = firstName;
            _lastNamePassenger = lastName;
            _genderPassenger = gender;
            BirthDatePassenger = birthDay;
            _typePassenger = type;
        }

        [Key]
        public int IdPassenger { get => _idPassenger; set => _idPassenger = value; }
        [Required]
        public string FirstNamePassenger { get => _firstNamePassenger; set => _firstNamePassenger = value; }
        [Required]
        public string LastNamePassenger { get => _lastNamePassenger; set => _lastNamePassenger = value; }
        [Required]
        public bool GenderPassenger { get => _genderPassenger; set => _genderPassenger = value; }
        public int DayBirthDatePassenger { get => BirthDatePassenger.Day; }
        public int MonthBirthDatePassenger { get => BirthDatePassenger.Month; }
        public int YearBirthDatePassenger { get => BirthDatePassenger.Year; }
        [Required]
        public int TypePassenger { get => _typePassenger; set => _typePassenger = value; }
        [NotMapped]
        public DateTime BirthDatePassenger { get => _birthDatePassenger; set => _birthDatePassenger = value; }

        public override string ToString()
        {
            return $"""
                ____________________________________________________________________
                PASSENGER DETAILS:
                Id: {_idPassenger}
                First name: {_firstNamePassenger}   Last name: {_lastNamePassenger}
                Gender: {_genderPassenger}          Birthdate: {BirthDatePassenger}
                Type:   {_typePassenger}
                _____________________________________________________________________
                """;
        }
    }
}
