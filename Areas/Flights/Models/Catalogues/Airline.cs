using System.ComponentModel.DataAnnotations;

namespace MVC_ProyectoFinal.Areas.Flights.Models.Catalogues
{
    public class Airline
    {
        private int _idAirline;
        private string _nameAirline;

        public Airline(int id, string name)
        {
            _idAirline = id;
            _nameAirline = name;
        }

        [Key]
        public int IdAirline { get => _idAirline; set => _idAirline = value; }
        [Required]
        public string NameAirline { get => _nameAirline; set => _nameAirline = value; }
    }
}
