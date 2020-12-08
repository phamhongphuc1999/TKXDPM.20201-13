// --------------------RENTAL BIKE APP-----------------
//
//
// Copyright (c) Microsoft. All Rights Reserved.
// License under the Apache License, Version 2.0.
//
//   Su Huu Vu Quang
//   Pham Hong Phuc
//   Tran Minh Quang
//   Ngo Minh Quang
//
//
// ------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    [Table("users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "CardId is required")]
        [ForeignKey("Card")]
        public int CardId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 100, ErrorMessage = "Age between 0 and 100")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "password is too short, at least 6 characters")]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CusAddress is reuqired")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone is required")]
        [Phone]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is required")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "AccountStatus is required")]
        public string AccountStatus { get; set; }
    }

    public class NewUserInfo
    {
        [Required(ErrorMessage = "CardId is required")]
        [ForeignKey("Card")]
        public int CardId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(200)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, 100, ErrorMessage = "Age between 0 and 100")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "password is too short, at least 6 characters")]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "CusAddress is reuqired")]
        [StringLength(200)]
        public string Address { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone is required")]
        [Phone]
        public string Phone { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is required")]
        [StringLength(10)]
        public string Gender { get; set; }
    }
}
