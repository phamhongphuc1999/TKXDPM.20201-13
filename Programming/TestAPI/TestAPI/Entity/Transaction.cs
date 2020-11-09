using System.ComponentModel.DataAnnotations;

namespace TestAPI.Entity
{
    public class Transaction
    {
        [Required]
        public string cardCode { get; set; }

        [Required]
        public string owner { get; set; }

        [Required]
        public string cvvCode { get; set; }

        [Required]
        public string dateExpired { get; set; }

        [Required]
        public string command { get; set; }

        [Required]
        public string transactionContent { get; set; }

        [Required]
        public int amount { get; set; }

        [Required]
        public string createdAt { get; set; }
    }
}
