using CareYou.DataClass;
using CareYou.Handler;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CareYou.Controller
{
    public class userController
    {
        public static top10Data getTop3User(int rank)
        {
            if (rank == 1)
            {
                return userHandler.getTop1Data("user");
            }
            else if (rank == 2)
            {
                return userHandler.getTop2Data("user");
            }
            else if (rank == 3)
            {
                return userHandler.getTop3Data("user");
            }

            return null;
        }

        public static List<top10Data> get4to10User()
        {
            return userHandler.getTop4to10("user");
        }

        public static top10Data getTop3Organization(int rank)
        {
            if (rank == 1)
            {
                return userHandler.getTop1Data("organization");
            }
            else if (rank == 2)
            {
                return userHandler.getTop2Data("organization");
            }
            else if (rank == 3)
            {
                return userHandler.getTop3Data("organization");
            }

            return null;
        }

        public static List<top10Data> get4to10Organization()
        {
            return userHandler.getTop4to10("organization");
        }

        public static int getTotalDonationFromUserID(int userId)
        {
            return userHandler.getTotalDonationFromUser(userId);
        }

        public static int getUserRank(int id)
        {
            return userHandler.getUserRank(id);
        }

        public static int getOrganizationRank(int id)
        {
            return userHandler.getOrganizationRank(id);
        }

        public static Response<User> checkUPNameField(String name)
        {
            if (name == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Please fill this field",
                    Field = "name",
                    Payload = null
                };
            }
            else if (name.Length < 3 || name.Length > 50)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Length of name must be between 3 - 50 characters",
                    Field = "name",
                    Payload = null
                };
            }

            return new Response<User>()
            {
                Success = true,
                Message = "",
                Field = "name",
                Payload = null
            };
        }

        public static Response<User> checkUPPassField(String pass)
        {
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            if (pass == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Please fill this field",
                    Field = "password",
                    Payload = null
                };
            }else if(pass.Length < 6)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Length must be at least 6 character",
                    Field = "password",
                    Payload = null
                };
            }
            else if (!alphanumeric.IsMatch(pass))
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Password must be alphanumeric",
                    Field = "password",
                    Payload = null
                };
            }

            return new Response<User>()
            {
                Success = true,
                Message = "",
                Field = "password",
                Payload = null
            };
        }

        public static Response<User> checkUPCPassField(String cPass, String pass)
        {
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            if (cPass == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Please fill this field",
                    Field = "cpassword",
                    Payload = null
                };
            }
            else if (!cPass.Equals(pass))
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Confirm Password didn't match",
                    Field = "cpassword",
                    Payload = null
                };
            }

            return new Response<User>()
            {
                Success = true,
                Message = "",
                Field = "cpassword",
                Payload = null
            };
        }

        public static Response<User> checkUPEmailField(String email)
        {
            if (email == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Please fill this field",
                    Field = "email",
                    Payload = null
                };
            }else if (!email.Contains("@") || !email.Contains(".") || email.IndexOf("@") == 0 || email.IndexOf(".") == 0 || email.IndexOf("@") == email.Length - 1 || email.IndexOf(".") == email.Length - 1)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Email format wrong",
                    Field = "email",
                    Payload = null
                };
            }

            return new Response<User>()
            {
                Success = true,
                Message = "",
                Field = "email",
                Payload = null
            };
        }


        public static Response<User> updateProfile(User curr, String name, String email, String password, String cPassword)
        {
            bool cekname = checkUPNameField(name).Success;
            bool cekpass = checkUPPassField(password).Success;
            bool cekEmail = checkUPEmailField(email).Success;
            bool cekcpass = checkUPCPassField(cPassword, password).Success;

            if (checkUPNameField(name).Success && checkUPPassField(password).Success && checkUPEmailField(email).Success && checkUPCPassField(cPassword, password).Success)
            {
                return userHandler.updateProfile(curr, name, email, password);
            }

            return new Response<User>()
            {
                Success = false,
                Message = "",
                Field = "msUser",
                Payload = null
            };
        }

        public static Response<User> doLogin(String email, String password)
        {
            Response<User> cekPass = checkUPPassField(password);
            Response<User> cekEmail = checkUPEmailField(email);
            if(cekPass.Success && cekEmail.Success)
            {
                return userHandler.Login(email, password);
            }
            if (!cekEmail.Success)
            {
                return cekEmail;
            }
            return cekPass;
        }

        public static Response<User> doRegister(String fname, String lname, String email, String password, String cPassword)
        {
            Response<User> cekname = checkUPNameField(fname);
            Response<User> cekEmail = checkUPEmailField(email);
            Response<User> cekPass = checkUPPassField(password);
            Response<User> cekcpass = checkUPCPassField(cPassword, password);

            if (cekname.Success && cekEmail.Success && cekPass.Success && cekcpass.Success)
            {
                return userHandler.Register(fname + " " + lname, email, password);
            }

            if (!cekname.Success)
            {
                return cekname;
            }
            if (!cekEmail.Success)
            {
                return cekEmail;
            }
            if (!cekPass.Success)
            {
                return cekPass;
            }
            return cekcpass;
        }

        public static Response<User> doForgotPassword(String email)
        {
            Response<User> cekEmail = checkUPEmailField(email);
            if (cekEmail.Success)
            {
                return userHandler.forgotPassword(email);
            }
            return cekEmail;
        }

        public static Response<User> doChangePassword(String email, String password, String cPassword)
        {
            Response<User> cekPass = checkUPPassField(password);
            Response<User> cekcpass = checkUPCPassField(cPassword, password);
            if (cekPass.Success && cekcpass.Success)
            {
                return userHandler.changePassword(email, password);
            }
            if (!cekPass.Success)
            {
                return cekPass;
            }
            return cekcpass;
        }
    }
}