using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Factory
{
    public class TransactionFactory
    {
        public static Transaction Create(int UserID, DateTime TransactionDate, int Amount, string TransactionType, int ProgramID)
        {
            Transaction transaction = new Transaction();
            transaction.TransactionID = transactionRepo.generateId();
            transaction.UserID = UserID;
            transaction.TransactionDate = TransactionDate;
            transaction.Amount = Amount;
            transaction.TransactionType = TransactionType;
            transaction.ProgramID = ProgramID;
            return transaction;
        }

        public static Donation CreateDonation(int TransactionID, string paymentMethod, bool isAnonymous)
        {
            Donation donation = new Donation();
            donation.TransactionID = TransactionID;
            donation.PaymentMethod = paymentMethod;
            donation.isAnonymous = isAnonymous;
            return donation;
        }

        public static Withdrawal CreateWithdrawal(int TransactionID, string withdrawalMethod)
        {
            Withdrawal withdrawal = new Withdrawal();
            withdrawal.TransactionID = TransactionID;
            withdrawal.WithdrawMethod = withdrawalMethod;
            return withdrawal;
        }

        public static Withdrawal CreateWithdrawal(int TransactionID, string withdrawalMethod, string BankAccount, string BankName)
        {
            Withdrawal withdrawal = new Withdrawal();
            withdrawal.TransactionID = TransactionID;
            withdrawal.WithdrawMethod = withdrawalMethod;
            withdrawal.BankAccount = BankAccount;
            withdrawal.BankName = BankName;
            return withdrawal;
        }
    }
}