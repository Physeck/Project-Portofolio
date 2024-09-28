using CareYou.DataClass;
using CareYou.Factory;
using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Handler
{
    public class transactionHandler
    {
        public static List<Transaction> getTransactionBasedOnDateAndUserID(DateTime date, int id)
        {
            return transactionRepo.getTransactionBasedOnDateAndUserID(date, id);
        }

        public static List<Transaction> getTransactionBasedOnUserID(int id)
        {
            return transactionRepo.getTransactionByUserID(id);
        }

        public static List<Transaction> getTransactionBasedOnTypeAndDateAndUserID(DateTime date, String type, int id)
        {
            return transactionRepo.getTransactionBasedOnTypeAndDateAndUserID(date, type, id);
        }
        public static int createNewTransaction(int UserID, DateTime TransactionDate, int Amount, string TransactionType, int ProgramID, string TransactionMethod, bool isAnonymous)
        {
            int transactionId = transactionRepo.insertTransaction(UserID, TransactionDate, Amount, TransactionType, ProgramID);
            transactionRepo.insertDonation(transactionId, TransactionMethod, isAnonymous);
            programRepo.updateProgramRaised(ProgramID, Amount);
            return transactionId;
        }

        public static dynamic createNewWithdrawal(int UserID, DateTime TransactionDate, int Amount, string TransactionType, int ProgramID, string TransactionMethod)
        {
            Program program = programRepo.getProgramById(ProgramID);
            if((Amount+program.Withdrawn) > program.ProgramRaised)
            {
                return new
                {
                    response = "Withdrawal amount exceeds the raised amount",
                };
            }
            int transactionId = transactionRepo.insertTransaction(UserID, TransactionDate, Amount, TransactionType, ProgramID);
            transactionRepo.insertWithdrawal(transactionId, TransactionMethod);
            programRepo.updateProgramWithdrawn(ProgramID, Amount);
            return new
            {
                response = "",
                transactionId = transactionId
            };
        }

        public static void addComment(int transactionId, String comment)
        {
            transactionRepo.addComment(transactionId, comment);
        }

        public static String getSumOfDonations()
        {
            int sum = transactionRepo.getSumOfDonations();
            if(sum > 1000000)
            {
                return (sum / 1000000).ToString() + "M";
            }
            else if(sum > 1000)
            {
                return (sum / 1000).ToString() + "K";
            }else if(sum > 1000000000)
            {
                return (sum / 1000000000).ToString() + "B";
            }

            return sum.ToString();
        }
    }
}