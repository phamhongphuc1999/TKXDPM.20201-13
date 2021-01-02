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
    /// <summary>
    /// reqresenting the users table in database
    /// </summary>
    [Table("users")]
    public class User
    {
        /// <summary>
        /// user id
        /// </summary>
        [Key]
        public int UserId { get; private set; }

        /// <summary>
        /// username
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(100)]
        public string Username { get; private set; }

        /// <summary>
        /// password
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "password is too short, at least 6 characters")]
        [MaxLength(100)]
        public string Password { get; private set; }

        /// <summary>
        /// account status
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "AccountStatus is required")]
        public string AccountStatus { get; private set; }

        /// <summary>
        /// contructor of User
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
            this.AccountStatus = "enable";
        }
    }

    /// <summary>
    /// the information when user login
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// username
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
        [StringLength(100)]
        public string Username { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "password is too short, at least 6 characters")]
        [MaxLength(100)]
        public string Password { get; set; }
    }
}
