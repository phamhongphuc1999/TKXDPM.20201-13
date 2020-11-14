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
        [StringLength(100)]
        public string QRCode { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(20)]
        public string Category { get; set; }

        [StringLength(20)]
        public string LicensePlate { get; set; }

        [Required(ErrorMessage = "Manufacturer is required")]
        [StringLength(200)]
        public string Manufacturer { get; set; }

        [Required(ErrorMessage = "BikeStatus is required")]
        public bool BikeStatus { get; set; }
    }
}
