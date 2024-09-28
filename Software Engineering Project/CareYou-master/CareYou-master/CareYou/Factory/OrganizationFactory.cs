using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Factory
{
    public class OrganizationFactory
    {
        public static Organization Create(int userId, String name, String type, String location, String phone, String email, String website, String leaderName, String cert) 
        {
            Organization organization = new Organization();
            organization.UserID = userId;
            organization.Name = name;
            organization.Type = type;
            organization.Location = location;
            organization.PhoneNumber = phone;
            organization.Email = email;
            organization.Website = website;
            organization.LeaderName = leaderName;
            organization.Certificate = cert;
            organization.isVerified = false;
            return organization;
        }
        public static Organization Create(int userId, String name, String type, String location, String phone, String email, String leaderName, String cert) 
        {
            Organization organization = new Organization();
            organization.UserID = userId;
            organization.Name = name;
            organization.Type = type;
            organization.Location = location;
            organization.PhoneNumber = phone;
            organization.Email = email;
            organization.LeaderName = leaderName;
            organization.Certificate = cert;
            organization.isVerified = false;
            return organization;
        }
    }
}