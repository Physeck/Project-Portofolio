using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Repository
{
    public class badgeRepository
    {
        static CareYouDBEntities db = DatabaseSingleton.getInstance();

        public static List<UserBadge> getUserBadgeFromUserID(int id)
        {
            return (from x in db.UserBadges where x.UserID == id select x).ToList();
        }
    }
}