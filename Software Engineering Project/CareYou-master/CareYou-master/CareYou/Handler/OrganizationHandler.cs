using CareYou.DataClass;
using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Handler
{
    public class OrganizationHandler
    {

        public static void RejectOrganization(int organizationId)
        {
            OrganizationRepo.RejectOrganization(organizationId);
        }

        public static void AcceptOrganization(int organizationId)
        {
            OrganizationRepo.AcceptOrganization(organizationId);
        }

        public static Organization getOrganizationById(int organizationId)
        {
            return OrganizationRepo.GetOrganizationByUserId(organizationId);
        }
        public static Response<Organization> CreateOrganization(int userId, String name, String type, String location, String phone, String email, String leaderName, HttpPostedFile cert)
        {
            Organization organization = OrganizationRepo.GetOrganizationByEmail(email.ToLower());
            if (organization != null)
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Email already registered",
                    Field = "email",
                    Payload = null
                };
            }
            String imageLoc = ProgramHandler.UploadFile(cert, "~/Organization/cert/");
            Organization org = OrganizationRepo.CreateOrganization(userId, name, type, location, phone, email.ToLower(), leaderName, imageLoc);

            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = org
            };

        }

        public static Response<Organization> CreateOrganization(int userId, String name, String type, String location, String phone, String email, String website, String leaderName, HttpPostedFile cert)
        {
            Organization organization = OrganizationRepo.GetOrganizationByEmail(email.ToLower());
            if (organization != null)
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Email already registered",
                    Field = "email",
                    Payload = null
                };
            }
            String imageLoc = ProgramHandler.UploadFile(cert, "~/Organization/cert/");
            Organization org = OrganizationRepo.CreateOrganization(userId, name, type, location, phone, email.ToLower(), website, leaderName, imageLoc);
            User user = userRepo.GetUserById(userId);
            userRepo.changeRole(user, "organization");
            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = org
            };

        }

        public static Organization GetOrganizationByUserId(int userId)
        {
            return OrganizationRepo.GetOrganizationByUserId(userId);
        }

        public static List<Organization> getAllPendingOrganizations()
        {
            return OrganizationRepo.getAllPendingOrganizations();
        }
    }
}