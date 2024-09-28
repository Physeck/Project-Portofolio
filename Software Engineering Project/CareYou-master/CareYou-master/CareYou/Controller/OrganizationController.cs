using CareYou.DataClass;
using CareYou.Handler;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Controller
{
    public class OrganizationController
    {
        public static Response<Organization> checkName(String name)
        {
            if (name == "")
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Name cannot be empty",
                    Field = "name",
                    Payload = null
                };
            }
            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = null
            };
        } 

        public static Response<Organization> checkType(String type)
        {
            if (type == "")
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Type cannot be empty",
                    Field = "type",
                    Payload = null
                };
            }
            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = null
            };
        }

        public static Response<Organization> checkLocation(String location)
        {
            if (location == "")
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Location cannot be empty",
                    Field = "location",
                    Payload = null
                };
            }
            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = null
            };
        }

        public static Response<Organization> checkPhone(String phone)
        {
            if (phone == "")
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Phone cannot be empty",
                    Field = "phone",
                    Payload = null
                };
            }else if(phone.Length < 10 || phone.Length > 13)
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Phone is invalid!",
                    Field = "phone",
                    Payload = null
                };
            }
            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = null
            };
        }

        public static Response<Organization> checkEmail(String email)
        {
            if (email == "")
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Email cannot be empty",
                    Field = "email",
                    Payload = null
                };
            }else if(!email.Contains("@") || !email.Contains(".") || email.IndexOf("@") == 0 || email.IndexOf(".") == 0 || email.IndexOf("@") == email.Length - 1 || email.IndexOf(".") == email.Length - 1)
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Email is invalid!",
                    Field = "email",
                    Payload = null
                };
            }
            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = null
            };
        }

        public static Response<Organization> checkLeaderName(String leaderName)
        {
            if (leaderName == "")
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Leader Name cannot be empty",
                    Field = "leaderName",
                    Payload = null
                };
            }
            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = null
            };
        }

        public static Response<Organization> checkCert(HttpPostedFile cert)
        {
            if (cert.ContentLength <= 0)
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Please upload a file",
                    Field = "cert",
                    Payload = null
                };
            }
            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = null
            };
        }

        public static Response<Organization> checkConfirmation(bool confirmation)
        {
            if (!confirmation)
            {
                return new Response<Organization>()
                {
                    Success = false,
                    Message = "Please confirm the data",
                    Field = "confirmation",
                    Payload = null
                };
            }
            return new Response<Organization>()
            {
                Success = true,
                Message = "",
                Field = "",
                Payload = null
            };
        }



        public static Response<Organization> createOrganization(int userId, String name, String type, String location, String phone, String email, String website, String leaderName, HttpPostedFile cert, bool confirmation)
        {
            Response<Organization> cekName = checkName(name);
            Response<Organization> cekType = checkType(type);
            Response<Organization> cekLocation = checkLocation(location);
            Response<Organization> cekPhone = checkPhone(phone);
            Response<Organization> cekEmail = checkEmail(email);
            Response<Organization> cekLeaderName = checkLeaderName(leaderName);
            Response<Organization> cekCert = checkCert(cert);
            Response<Organization> cekConfirmation = checkConfirmation(confirmation);

            if(cekName.Success && cekType.Success && cekLocation.Success && cekPhone.Success && cekEmail.Success && cekLeaderName.Success && cekCert.Success && cekConfirmation.Success)
            {
                return OrganizationHandler.CreateOrganization(userId, name, type, location, phone, email, website, leaderName, cert);
            }
            if (!cekName.Success)
            {
                return cekName;
            }
            if (!cekType.Success)
            {
                return cekType;
            }
            if (!cekLocation.Success)
            {
                return cekLocation;
            }
            if (!cekPhone.Success)
            {
                return cekPhone;
            }
            if (!cekEmail.Success)
            {
                return cekEmail;
            }
            if (!cekLeaderName.Success)
            {
                return cekLeaderName;
            }
            if (!cekCert.Success)
            {
                return cekCert;
            }
            return cekConfirmation;  
        }

        public static Response<Organization> createOrganization(int userId, String name, String type, String location, String phone, String email, String leaderName, HttpPostedFile cert, bool confirmation)
        {
            Response<Organization> cekName = checkName(name);
            Response<Organization> cekType = checkType(type);
            Response<Organization> cekLocation = checkLocation(location);
            Response<Organization> cekPhone = checkPhone(phone);
            Response<Organization> cekEmail = checkEmail(email);
            Response<Organization> cekLeaderName = checkLeaderName(leaderName);
            Response<Organization> cekCert = checkCert(cert);
            Response<Organization> cekConfirmation = checkConfirmation(confirmation);
            if (cekName.Success && cekType.Success && cekLocation.Success && cekPhone.Success && cekEmail.Success && cekLeaderName.Success && cekCert.Success && cekConfirmation.Success)
            {
                return OrganizationHandler.CreateOrganization(userId, name, type, location, phone, email, leaderName, cert);
            }
            if (!cekName.Success)
            {
                return cekName;
            }
            if (!cekType.Success)
            {
                return cekType;
            }
            if (!cekLocation.Success)
            {
                return cekLocation;
            }
            if (!cekPhone.Success)
            {
                return cekPhone;
            }
            if (!cekEmail.Success)
            {
                return cekEmail;
            }
            if (!cekLeaderName.Success)
            {
                return cekLeaderName;
            }
            if (!cekCert.Success)
            {
                return cekCert;
            }
            return cekConfirmation;
        }
    }
}