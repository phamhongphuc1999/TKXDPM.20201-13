using NUnit.Framework;
using RentalBikeApp.Business.SQLServices;
using RentalBikeApp.Entities.SQLEntities;
using System;
using System.Collections.Generic;

namespace ReantalBikeTest
{
    [TestFixture]
   class TransactionServiceTests
    {
       
        private TransactionService transactionservice;
        [SetUp]
        public void Setup()
        {
            transactionservice = new TransactionService();
        }

        [Test]
        public void InsertNewTransactionTest()
        {
            Transaction transaction = new Transaction()
            {
                UserId = 1,
                BikeId = 2,
                Deposit = 1000000,
                RentalMoney = 0,
                TotalTimeRent = 0,
                DateTransaction = DateTime.Now
            };

            Assert.IsNotNull(transaction);
            
        }

        [Test]
        public void GetTransactionByIdTest()
        {
            Transaction transaction = transactionservice.GetTransactionById(1);
            Assert.IsNotNull(transaction);
        }

        [Test]
        public void GetLastTransactionByUserIdTest()
        {
            Transaction transaction = transactionservice.GetLastTransactionByUserId(3);
            Assert.IsNotNull(transaction);
        }

        [Test]
        public void GetListTransactionsByUserIdTest()
        {
            List<Transaction> transactions = transactionservice.GetListTransactionsByUserId(1);
            Assert.IsTrue(transactions.Count > 0);
        }

        [Test]
        public void UpdateTransactionTest()
        {
            DateTime aDateTime = new DateTime(2020, 12, 20, 00, 00, 00);
            bool result = transactionservice.UpdateTransaction(1,10000,aDateTime,"");
            Assert.IsTrue(result);
        }
    }
}
