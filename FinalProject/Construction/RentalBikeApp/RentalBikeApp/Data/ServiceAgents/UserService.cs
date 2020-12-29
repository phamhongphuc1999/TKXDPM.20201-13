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

using RentalBikeApp.Entities.SQLEntities;
using System.Linq;

namespace RentalBikeApp.Data.ServiceAgents
{
    /// <summary>
    /// Provides functions to interact with user in the database
    /// </summary>
    public class UserService: BaseService
    {
        /// <summary>
        /// contructor of UserService
        /// </summary>
        /// <param name="connecter">The instance representing connection to database</param>
        public UserService(SQLConnecter connecter): base(connecter) { }

        /// <summary>
        /// Login user into program
        /// </summary>
        /// <param name="loginUser">Login user information</param>
        /// <returns>null if login fail or user information if login success</returns>
        public User UserLogin(UserInfo loginUser)
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
        public User InsertNewUser(UserInfo newUser)
        {
            User checkUser = connecter.SqlData.Users.SingleOrDefault(x => x.Username == newUser.Username);
            if (checkUser != null) return null;
            User user = new User(newUser.Username, newUser.Password);
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
