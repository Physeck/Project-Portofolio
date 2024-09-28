using CareYou.DataClass;
using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Handler
{
    public class ReportHandler
    {
        public static Response<ReportedProgram> CreateReport(int programId, bool isScam, bool isFraud, bool isThirdparty, string otherReason)
        {
            ReportedProgram report = ReportRepository.CreateNewReport(programId, isScam, isFraud, isThirdparty, otherReason);
            return new Response<ReportedProgram>()
            {
                Success = true,
                Message = "",
                Field = "report",
                Payload = report
            };
        }

        public static void ApproveReport(int reportId)
        {
            ReportRepository.ApproveReport(reportId);
        }
    }
}