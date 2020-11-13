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
        public string Bank { get; set; }

        [Required(ErrorMessage = "ExpirationDate is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "SecurityCode is required")]
        public string SecurityCode { get; set; }

        [Required(ErrorMessage = "PrivateToken is required")]
        public string PrivateToken { get; set; }

        public string Note { get; set; }
    }
}
