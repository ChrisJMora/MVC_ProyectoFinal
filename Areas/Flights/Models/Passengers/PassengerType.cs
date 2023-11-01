using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_ProyectoFinal.Areas.Flights.Models.Passengers
{
    public class PassengerType
    {
        private int _idPassangerType;
        private string _namePassengerType;
        private bool _viewPassengerType;

        public PassengerType(int id, string name, bool view )
        {
            _idPassangerType = id;
            _namePassengerType = name;
            _viewPassengerType = view;
        }

        [Key]
        public int IdPassangerType { get => _idPassangerType; set => _idPassangerType = value; }
        [Required]
        public string NamePassengerType { get => _namePassengerType; set => _namePassengerType = value; }
        [Required]
        public bool ViewPassengerType { get => _viewPassengerType; set => _viewPassengerType = value; }

        public override int GetHashCode()
        {
            return _idPassangerType.GetHashCode();
        }

        public override bool Equals(object? obj)
        {   
            if (obj == null) return false;
            if (obj is PassengerType passengerType)
            {
                return _idPassangerType == passengerType._idPassangerType;
            }
            return false;
        }

    }
}
