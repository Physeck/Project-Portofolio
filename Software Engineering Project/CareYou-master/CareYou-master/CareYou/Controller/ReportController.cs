using CareYou.DataClass;
using CareYou.Handler;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Controller
{
    public class ReportController
    {
        public static Response<ReportedProgram> isOtherChecked(bool isOther, String reason)
        {
            if(isOther && reason == "")
            {
                return new Response<ReportedProgram>()
                {
                    Success = false,
                    Message = "Please fill in the reason",
                    Field = "reason",
                    Payload = null
                };
            }
            return new Response<ReportedProgram>()
            {
                Success = true,
                Message = "",
                Field = "reason",
                Payload = null
            };
        }

        public static Response<ReportedProgram> isAnyChecked(bool isScam, bool isFraud, bool isThirdparty, bool isOther)
        {
            if (!isScam && !isFraud && !isThirdparty && !isOther)
            {
                return new Response<ReportedProgram>()
                {
                    Success = false,
                    Message = "Please check at least one reason",
                    Field = "reason",
                    Payload = null
                };
            }
            return new Response<ReportedProgram>()
            {
                Success = true,
                Message = "",
                Field = "reason",
                Payload = null
            };
        }

        public static Response<ReportedProgram> CreateReport(int programId, bool isScam, bool isFraud, bool isThirdparty, bool isOther, string otherReason)
        {
            Response<ReportedProgram> checkOther = isOtherChecked(isOther, otherReason);
            Response<ReportedProgram> checkAny = isAnyChecked(isScam, isFraud, isThirdparty, isOther);
            if (checkOther.Success && checkAny.Success)
            {
                return ReportHandler.CreateReport(programId, isScam, isFraud, isThirdparty, otherReason);
            }
            if(!checkAny.Success)
            {
                return checkAny;
            }
            return checkOther;
        }
    }
}