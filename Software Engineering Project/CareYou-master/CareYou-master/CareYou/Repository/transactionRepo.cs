using CareYou.Factory;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Util;

namespace CareYou.Repository
{
    public class transactionRepo
    {
        static CareYouDBEntities db = DatabaseSingleton.getInstance();
        public static int getUserAmount(User user)
        {
            if (user.Transactions.Count == 0)
            {
                return 0;
            }

            int amount = db.Transactions.Where(x => x.UserID == user.UserID).Sum(x => x.Amount);
            return amount;
        }

        public static List<Transaction> getTransactionByUserID(int userID)
        {
            return (from x in db.Transactions where x.UserID == userID select x).ToList();
        }

        public static List<Transaction> getTransactionByProgramId(int programId)
        {
            return (from x in db.Transactions where x.ProgramID == programId orderby x.TransactionDate descending select x).ToList();
        }

        public static List<Transaction> getDonationsByProgramId(int programId)
        {
            return (from x in db.Transactions where x.ProgramID == programId && x.TransactionType.Equals("donation") orderby x.TransactionDate descending select x).ToList();
        }

        public static List<Transaction> getDonationFromUserID(int id)
        {
            return (from x in db.Transactions where x.TransactionType.Equals("donation") && x.UserID == id select x).ToList();
        }

        public static List<Transaction> getWithdrawalFromUserID(int id)
        {
            return (from x in db.Transactions where x.TransactionType.Equals("withdrawal") && x.UserID == id select x).ToList();
        }

        public static List<Transaction> getTransactionBasedOnDateAndUserID(DateTime date, int id)
        {
            return (from x in db.Transactions where x.TransactionDate >= date && x.UserID == id select x).ToList();
        }
        public static List<Transaction> getTransactionBasedOnTypeAndDateAndUserID(DateTime date, String type, int id)
        {
            return (from x in db.Transactions where x.TransactionDate >= date && x.TransactionType.Equals(type) && x.UserID == id select x).ToList();
        }


        public static int generateId()
        {
            Transaction lastTransaction = db.Transactions.ToList().LastOrDefault();
            if (lastTransaction == null)
            {
                return 1;
            }
            int lastId = lastTransaction.TransactionID;
            return lastId + 1;
        }

        public static int insertTransaction(int UserID, DateTime TransactionDate, int Amount, string TransactionType, int ProgramID)
        {
            Transaction transaction = TransactionFactory.Create(UserID, TransactionDate, Amount, TransactionType, ProgramID);
            db.Transactions.Add(transaction);
            db.SaveChanges();
            return transaction.TransactionID;
        }

        public static void insertDonation(int transactionId, string paymentMethod, bool isAnonymous)
        {
            Donation donation = TransactionFactory.CreateDonation(transactionId, paymentMethod, isAnonymous);
            db.Donations.Add(donation);
            db.SaveChanges();
        }

        public static void insertWithdrawal(int transactionId, string withdrawalMethod)
        {
            Withdrawal withdrawal = TransactionFactory.CreateWithdrawal(transactionId, withdrawalMethod);
            db.Withdrawals.Add(withdrawal);
            db.SaveChanges();
        }

        public static void addComment(int transactionId, String comment)
        {
            Transaction transaction = db.Transactions.Find(transactionId);
            transaction.Donation.Comment = comment;
            db.SaveChanges();
        }

        public static int getSumOfDonations()
        {
            return db.Transactions.Where(x => x.TransactionType.Equals("donation")).Sum(x => x.Amount);
        }
    }
}