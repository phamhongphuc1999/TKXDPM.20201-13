using System.ComponentModel.DataAnnotations;

namespace RentalBikeApp.Entities.APIEntities
{
    public class ProcessTransaction
    {
        [Required]
        public string version { get; set; }

        [Required]
        public TransactionInfo transaction { get; set; }

        [Required]
        public string appCode { get; set; }

        [Required]
        public string hashCode { get; set; }
    }
}
