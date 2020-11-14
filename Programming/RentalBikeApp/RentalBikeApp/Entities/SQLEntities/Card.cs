using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    [Table("Cards")]
    public class Card
    {
        [Key]
        public int CardId { get; set; }

        [Required(ErrorMessage = "Bank is required")]
        [StringLength(100)]
        public string Bank { get; set; }

        [Required(ErrorMessage = "ExpirationDate is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "SecurityCode is required")]
        [StringLength(10)]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage = "PrivateToken is required")]
        [StringLength(100)]
        public string PrivateToken { get; set; }

        [StringLength(100)]
        public string Note { get; set; }
    }
}
