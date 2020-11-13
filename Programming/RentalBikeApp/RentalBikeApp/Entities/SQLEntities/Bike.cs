using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    [Table("Bikes")]
    public class Bike
    {
        [Key]
        public int BikeId { get; set; }

        [Required(ErrorMessage = "StationId is required")]
        [ForeignKey("Station")]
        public int StationId { get; set; }

        [Required(ErrorMessage = "QRCode is required")]
        public string QRCode { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "BikeStatus is required")]
        public string BikeStatus { get; set; }
    }
}
