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

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalBikeApp.Entities.SQLEntities
{
    [Table("users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "password is too short, at least 6 characters")]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "AccountStatus is required")]
        public string AccountStatus { get; set; }
    }

    public class UserInfo
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "password is too short, at least 6 characters")]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
