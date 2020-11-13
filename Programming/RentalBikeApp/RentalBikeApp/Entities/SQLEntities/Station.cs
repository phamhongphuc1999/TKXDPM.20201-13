using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    [Table("Stations")]
    public class Station
    {
        [Key]
        public int StationId { get; set; }

        [Required(ErrorMessage = "NameStation is required")]
        public string NameStation { get; set; }

        [Required(ErrorMessage = "AddressStation is required")]
        public string AddressStation { get; set; }

        [Required(ErrorMessage = "AreaStaion is required")]
        public int AreaStaion { get; set; }

        [Required(ErrorMessage = "NumberOfBike is required")]
        public int NumberOfBike { get; set; }

        public string Note { get; set; }
    }
}
