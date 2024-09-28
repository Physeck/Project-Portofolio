using CareYou.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Controller
{
    public class badgeController
    {
        public static userBadgeData getBadgeByUserID(int id)
        {
            userBadgeData data = new userBadgeData();
            data.totalBadge = badgeHandler.getBadgeByUserID(id).Count();
            data.badges = badgeHandler.getBadgeByUserID(id);
            return data;
        }
    }
}