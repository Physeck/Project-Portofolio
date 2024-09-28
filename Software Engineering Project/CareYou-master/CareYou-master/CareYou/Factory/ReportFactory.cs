using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Factory
{
    public class ReportFactory
    {
        public static ReportedProgram Create(int programId, bool isScam, bool isFraud, bool isThirdparty, string otherReason)
        {
            ReportedProgram report = new ReportedProgram();
            report.ReportID = ReportRepository.GenerateNewReportID();
            report.ProgramID = programId;
            report.ScamFundraise = isScam;
            report.FraudFundraise = isFraud;
            report.ThirdpartyBeneficiary = isThirdparty;
            report.OtherReason = otherReason;
            report.DateReported = DateTime.Now;
            report.ReportStatus = "pending";
            return report;

        }
    }
}