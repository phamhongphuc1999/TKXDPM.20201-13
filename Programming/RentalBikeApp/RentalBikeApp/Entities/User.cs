using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities
{
    [Table("users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "CardId is required")]
        public int CardId { get; set; }

        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 100, ErrorMessage = "Age between 0 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "AccountName is required")]
        public string AccountName { get; set; }

        [Required(ErrorMessage = "AccountPassword is required")]
        public string AccountPassword { get; set; }

        [Required(ErrorMessage = "CusAddress is reuqired")]
        public string CusAddress { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "AccountStatus is required")]
        public string AccountStatus { get; set; }
    }
}
