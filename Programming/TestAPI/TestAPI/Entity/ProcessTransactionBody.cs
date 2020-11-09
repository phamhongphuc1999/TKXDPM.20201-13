using System.ComponentModel.DataAnnotations;

namespace TestAPI.Entity
{
    public class ProcessTransactionBody
    {
        [Required]
        public string version { get; set; }

        [Required]
        public Transaction transaction { get; set; }

        [Required]
        public string appCode { get; set; }

        [Required]
        public string hashCode { get; set; }
    }
}
