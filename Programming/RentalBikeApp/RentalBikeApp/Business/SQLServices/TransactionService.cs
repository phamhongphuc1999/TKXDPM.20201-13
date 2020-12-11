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
using System;
using System.Collections.Generic;
using System.Linq;
using static RentalBikeApp.Program;

namespace RentalBikeApp.Business.SQLServices
{
    public class TransactionService
    {
        /// <summary>Insert new transaction when user deposit money to rent the bike</summary>
        /// <param name="userId">the Id of user who want to rent the bike</param>
        /// <param name="bikeId">the Id of rental bike</param>
        /// <param name="deposit">the desposit money to rent the bike</param>
        /// <returns>Return the new transaction or null if get error</returns>
        public Transaction InsertNewTransaction(int userId, int bikeId, int deposit)
        {
            User checkUser = connecter.SqlData.Users.Find(userId);
            if (checkUser == null) return null;
            BaseBike checkBike = connecter.SqlData.Bikes.Find(bikeId);
            if (checkBike == null) return null;
            Transaction transaction = new Transaction()
            {
                UserId = userId,
                BikeId = bikeId,
                Deposit = deposit,
                RentalMoney = 0,
                TotalTimeRent = 0,
                DateTransaction = DateTime.Now
            };
            connecter.SqlData.Transactions.Add(transaction);
            int check = connecter.SqlData.SaveChanges();
            if (check > 0) return transaction;
            else return null;
        }

        /// <summary>Get transaction by id</summary>
        /// <param name="transactionId">the id of specified transaction</param>
        /// <returns>Return the specified transaction</returns>
        public Transaction GetTransactionById(int transactionId)
        {
            return connecter.SqlData.Transactions.Find(transactionId);
        }

        /// <summary>Get last transaction of the user</summary>
        /// <param name="userId">the Id of user</param>
        /// <returns>Return the last transaction of the specified user</returns>
        public Transaction GetLastTransactionByUserId(int userId)
        {
            return connecter.SqlData.Transactions.LastOrDefault(x => x.UserId == userId);
        }

        /// <summary>Get all of transactions of the user</summary>
        /// <param name="userId">the Id of user</param>
        /// <returns>Return the specified user's transactions list</returns>
        public List<Transaction> GetListTransactionsByUserId(int userId)
        {
            return connecter.SqlData.Transactions.Where(x => x.UserId == userId).ToList();
        }

        /// <summary>Update the last transaction of the user after rented bike</summary>
        /// <param name="userId">the Id of user</param>
        /// <param name="rentalMoney">the rental money that user must to pay after rented bike</param>
        /// <param name="dateTransaction">the date of the transaction is process</param>
        /// <param name="note">note if necessary</param>
        /// <returns>Return true if success or false if cause error</returns>
        public bool UpdateTransaction(int userId, int rentalMoney, DateTime dateTransaction, string note = "")
        {
            Transaction transaction = connecter.SqlData.Transactions.LastOrDefault(x => x.UserId == userId);
            if (transaction == null) return false;
            transaction.RentalMoney = rentalMoney;
            transaction.DateTransaction = dateTransaction;
            if (note != "") transaction.Note = note;
            int check = connecter.SqlData.SaveChanges();
            return (check > 0);
        }
    }
}
