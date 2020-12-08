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
         Transaction tran = transactionservice.InsertNewTransaction(10, 4, 1000);

          Assert.IsNotNull(tran);
            
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
            List<Transaction> list = transactionservice.GetListTransactionsByUserId(1);
            Assert.IsTrue(list.Count > 0);
        }

        [Test]
        public void UpdateTransactionTest()
        {
            DateTime aDateTime = new DateTime(2005, 11, 20, 12, 1, 10);
            bool result = transactionservice.UpdateTransaction(1,1000,aDateTime,"");
            Assert.IsTrue(result);
        }
    }
}