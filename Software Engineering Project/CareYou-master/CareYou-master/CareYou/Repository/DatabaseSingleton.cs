using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Repository
{
    public class DatabaseSingleton
    {
        static CareYouDBEntities db = null;

        public static CareYouDBEntities getInstance()
        {
            if(db == null)
            {
                db = new CareYouDBEntities();
            }

            return db;
        }
    }
}