using System;
using System.ComponentModel.DataAnnotations;

namespace TestAPI.Entity
{
    [Serializable]
    public class Transaction
    {
        [Required]
        public string command { get; set; }

        [Required]
        public string cardCode { get; set; }

        [Required]
        public string owner { get; set; }

        [Required]
        public string cvvCode { get; set; }

        [Required]
        public string dateExpired { get; set; }

        [Required]
        public string transactionContent { get; set; }

        [Required]
        public int amount { get; set; }

        [Required]
        public string createdAt { get; set; }
    }

    [Serializable]
    public class TransactionABC
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
    }
}
