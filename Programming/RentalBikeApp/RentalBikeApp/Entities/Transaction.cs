using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "UserId is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "BikeId is required")]
        public int BikeId { get; set; }

        [Required(ErrorMessage = "Deposit is required")]
        public int Deposit { get; set; }

        [Required(ErrorMessage = "RentalMoney is required")]
        public int RentalMoney { get; set; }

        [Required(ErrorMessage = "TotalTimeRent is required")]
        public int TotalTimeRent { get; set; }

        [Required(ErrorMessage = "DateTransaction is required")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateTransaction { get; set; }

        public string Button { get; set; }
    }
}
