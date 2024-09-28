using CareYou.Handler;
using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Controller
{
    public class transactionController
    {
        public static List<Transaction> getTransactionBasedOnDateAndTypeAndUserID(int idxDate, String type, User curr)
        {

            if(idxDate == 0 && type.Equals("All"))
            {
                transactionHandler.getTransactionBasedOnUserID(curr.UserID);
            }

            DateTime date = curr.JoinDate;

            if (idxDate == 1)
            {
                date = DateTime.Now.AddDays(-3);
            }
            else if (idxDate == 2)
            {
                date = DateTime.Now.AddDays(-7);
            }
            else if (idxDate == 3)
            {
                date = DateTime.Now.AddDays(-21);
            }
            else if (idxDate == 4)
            {
                date = DateTime.Now.AddMonths(-1);
            }
            else if (idxDate == 5)
            {
                date = DateTime.Now.AddMonths(-3);
            }

            if (type.Equals("All"))
            {
                return transactionHandler.getTransactionBasedOnDateAndUserID(date, curr.UserID);
            }
            else
            {
                return transactionHandler.getTransactionBasedOnTypeAndDateAndUserID(date, type, curr.UserID);
            }
        }

        public static List<Transaction> getTransactionBasedOnUserID(int id)
        {
            return transactionHandler.getTransactionBasedOnUserID(id);
        }
    }
}