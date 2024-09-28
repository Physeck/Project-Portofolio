using CareYou.Factory;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Repository
{
    public class ReportRepository
    {
        static CareYouDBEntities db = DatabaseSingleton.getInstance();

        public static List<ReportedProgram> GetReports()
        {
            return db.ReportedPrograms.ToList();
        }

        public static void ApproveReport(int reportId)
        {
            ReportedProgram report = db.ReportedPrograms.Find(reportId);
            report.ReportStatus = "resolved";
            db.SaveChanges();
        }

        public static ReportedProgram GetReportById(int id)
        {
            return db.ReportedPrograms.Find(id);
        }

        public static void AddReport(ReportedProgram report)
        {
            db.ReportedPrograms.Add(report);
            db.SaveChanges();
        }

        public static void UpdateReport(ReportedProgram report)
        {
            db.Entry(report).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public static void DeleteReport(int id)
        {
            ReportedProgram report = db.ReportedPrograms.Find(id);
            db.ReportedPrograms.Remove(report);
            db.SaveChanges();
        }

        public static int GenerateNewReportID()
        {
            ReportedProgram lastReport = db.ReportedPrograms.ToList().LastOrDefault();
            if (lastReport == null)
            {
                return 1;
            }
            return lastReport.ReportID + 1;
        }

        public static ReportedProgram CreateNewReport(int programId, bool isScam, bool isFraud, bool isThirdparty, string otherReason)
        {
            ReportedProgram report = ReportFactory.Create(programId, isScam, isFraud, isThirdparty, otherReason);
            db.ReportedPrograms.Add(report);
            db.SaveChanges();
            return report;
        }
    }
}