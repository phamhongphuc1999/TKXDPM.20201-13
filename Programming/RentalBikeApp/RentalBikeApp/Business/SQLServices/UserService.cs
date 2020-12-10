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

using RentalBikeApp.Data;
using RentalBikeApp.Entities.SQLEntities;
using System.Linq;

namespace RentalBikeApp.Business.SQLServices
{
    public class UserService
    {
        private SQLConnecter connecter;

        public UserService()
        {
            connecter = new SQLConnecter(Config.SQL.SQL_CONNECT_STRING);
        }

        /// <summary>
        /// Login user into program
        /// </summary>
        /// <param name="loginUser">Login user information</param>
        /// <returns>null if login fail or user information if login success</returns>
        public User UserLogin(LoginUserInfo loginUser)
        {
            User user = connecter.SqlData.Users.SingleOrDefault(x => x.Username == loginUser.Username);
            if (user == null) return null;
            if (user.Password != loginUser.Password) return null;
            if (user.AccountStatus == "disable") return null;
            return user;
        }

        /// <summary>
        /// Insert new user in database
        /// </summary>
        /// <param name="newUser">user information to create new user</param>
        /// <returns>The User represent for new user</returns>
        public User InsertNewUser(NewUserInfo newUser)
        {
            User checkUser = connecter.SqlData.Users.SingleOrDefault(x => x.Username == newUser.Username);
            if (checkUser != null) return null;
            User user = new User()
            {
                Name = newUser.Name,
                Password = newUser.Password,
                Username = newUser.Username,
                Address = newUser.Address,
                Email = newUser.Email,
                Phone = newUser.Phone,
                Gender = newUser.Gender,
                AccountStatus = "enable"
            };
            connecter.SqlData.Users.Add(user);
            int check = connecter.SqlData.SaveChanges();
            if (check > 0) return user;
            else return null;
        }

        /// <summary>
        /// Delete user information from database
        /// </summary>
        /// <param name="username">The username of user want to delete</param>
        /// <returns>null if delete user fail or true if delete user success</returns>
        public User DeleteUserByUsername(string username)
        {
            User user = connecter.SqlData.Users.SingleOrDefault(x => x.Username == username);
            if (user == null) return null;
            connecter.SqlData.Users.Remove(user);
            int check = connecter.SqlData.SaveChanges();
            if (check > 0) return user;
            else return null;
        }
    }
}
