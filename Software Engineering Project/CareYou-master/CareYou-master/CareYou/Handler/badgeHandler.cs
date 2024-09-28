using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Handler
{
    public class badgeHandler
    {
        public static List<Badge> getBadgeByUserID(int id)
        {
            IEnumerable<UserBadge> badges = badgeRepository.getUserBadgeFromUserID(id);
            List<Badge> result = new List<Badge>();

            foreach (UserBadge badge in badges)
            {
                result.Add(badge.Badge);
            }

            return result;
        }
    }
}