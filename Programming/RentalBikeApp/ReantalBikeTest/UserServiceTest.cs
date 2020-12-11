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

using NUnit.Framework;
using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;

namespace ReantalBikeTest
{
    [TestFixture]
    class UserServiceTest
    {
        private UserService userService;

        [SetUp]
        public void Setup()
        {
            userService = new UserService();
        }

        /// <summary>
        /// Test for insert new user
        /// </summary>
        [Test, Order(0)]
        public void InsertNewUserTest()
        {
            UserInfo newUser = new UserInfo()
            {
                Password = "minhquang",
                Username ="quang.nm173326"
            };
            User user = userService.InsertNewUser(newUser);
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Test for insert new user with exist username
        /// </summary>
        [Test, Order(1)]
        public void InsertNewUserWithExistUsernameTest()
        {
            UserInfo newUser = new UserInfo()
            {
                Password = "minhquang",
                Username = "quang.nm173326"
            };
            User user = userService.InsertNewUser(newUser);
            Assert.IsNull(user);
        }

        /// <summary>
        /// Test for delete user base on username
        /// </summary>
        [Test, Order(2)]
        public void DeleteUserTest()
        {
            User user = userService.DeleteUserByUsername("quang.nm173326");
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Test for login with correct account
        /// </summary>
        [Test, Order(3)]
        public void LoginWithCorrectAccount()
        {
            User user = userService.UserLogin(new UserInfo
            {
                Username = "user1",
                Password = "123456789"
            });
            Assert.IsNotNull(user);
        }

        /// <summary>
        /// Test for login with error account
        /// </summary>
        [Test, Order(4)]
        public void LoginWithErrorAccount()
        {
            User user = userService.UserLogin(new UserInfo
            {
                Username = "user2",
                Password = "123456789"
            });
            Assert.IsNull(user);
        }
    }

}
