using CareYou.Factory;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Repository
{
    public class OrganizationRepo
    {
        static CareYouDBEntities db = DatabaseSingleton.getInstance();

        public static void RejectOrganization(int id)
        {
            Organization organization = db.Organizations.Find(id);
            organization.User.Role = "user";
            db.Organizations.Remove(organization);
            db.SaveChanges();
        }

        public static void AcceptOrganization(int id)
        {
            Organization organization = db.Organizations.Find(id);
            organization.isVerified = true;
            db.SaveChanges();
        }
        public static Organization GetOrganizationByUserId(int id)
        {
            return db.Organizations.Find(id);
        }

        public static Organization GetOrganizationByName(String name)
        {
            return (from x in db.Organizations where x.Name.Equals(name) select x).FirstOrDefault();
        }   

        public static Organization GetOrganizationByEmail(String email)
        {
            return (from x in db.Organizations where x.Email.Equals(email) select x).FirstOrDefault();
        }

        public static Organization CreateOrganization(int userId, String name, String type, String location, String phone, String email, String website, String leaderName, String cert)
        {
            Organization organization = OrganizationFactory.Create(userId, name, type, location, phone, email, website, leaderName, cert);
            db.Organizations.Add(organization);
            db.SaveChanges();
            return organization;
        }

        public static Organization CreateOrganization(int userId, String name, String type, String location, String phone, String email, String leaderName, String cert)
        {
            Organization organization = OrganizationFactory.Create(userId, name, type, location, phone, email, leaderName, cert);
            db.Organizations.Add(organization);
            db.SaveChanges();
            return organization;
        }

        public static List<Organization> getAllPendingOrganizations()
        {
            return (from x in db.Organizations where x.isVerified == false select x).ToList();
        }
    }
}