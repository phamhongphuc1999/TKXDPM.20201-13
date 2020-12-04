using System;
using System.Collections.Generic;
using System.Text;
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

        [Test]
        public void InsertNewUserTest()
        {
            User cus = new User()
            {
                CardId = 1,
                UserName = "Ngo Minh Quang",
                AccountPassword = "minhquang",
                AccountName ="quang.nm173326",
                CusAddress = "Ha Noi",
                Email = "quang.nm173326@gmail.com",
                Phone = "0969696969",
                Gender = "Nam",
                AccountStatus = "enable"
            };
            User user = userService.InsertNewUser(cus);
            Assert.IsNotNull(user);
        }
    }

}
