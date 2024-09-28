using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Factory
{
    public class UserFactory
    {
        public static User Create(String name, String email, String password)
        {
            User user = new User();
            user.UserName = name;
            user.UserEmail = email;
            user.UserPassword = password;
            user.Role = "user";
            user.JoinDate = DateTime.Now;
            user.UserStatus = "safe";
            user.ProfilePicture = "ProfileDefault.jpg";
            user.UserID = userRepo.generateUserId();
            return user;
        }
    }
}