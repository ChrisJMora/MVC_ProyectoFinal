using System.ComponentModel.DataAnnotations;

namespace MVC_ProyectoFinal.Areas.Flights.Models.Catalogues
{
    public class City
    {
        private int _idCity;
        private string _nameCity;

        public City(int id, string name)
        {
            _idCity = id;
            _nameCity = name;
        }

        [Key]
        public int IdCity { get => _idCity; set => _idCity = value; }
        [Required]
        public string NameCity { get => _nameCity; set => _nameCity = value; }
    }
}
