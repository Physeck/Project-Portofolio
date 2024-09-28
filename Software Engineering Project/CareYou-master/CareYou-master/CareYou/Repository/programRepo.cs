using CareYou.Factory;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Repository
{
    public class programRepo
    {
        static CareYouDBEntities db = DatabaseSingleton.getInstance();

        public static List<Program> getProgramsByUserID(int userID)
        {
            return (from x in db.Programs where x.User.UserID == userID select x).ToList();
        }

        public static void acceptProgram(int programID)
        {
            Program program = getProgramById(programID);
            program.Verified = true;
            db.SaveChanges();
        }

        public static void deleteProgramChanges(int programID)
        {
            ProgramChanges changes = getProgramChangesById(programID);
            db.ProgramChanges1.Remove(changes);
            db.SaveChanges();
        }
        public static void acceptProgramChanges(int programID)
        {
            ProgramChanges changes = getProgramChangesById(programID);
            Program program = getProgramById(programID);
            program.ProgramDesc = changes.ChangesDesc;
            program.ProgramTarget = changes.ChangesTarget;
            program.EndDate = changes.ChangesEndDate;
            program.ProgramImage = changes.ChangesImage;
            changes.isApproved = true;
            db.SaveChanges();
        }

        public static List<Program> getAllProgramsWithReports()
        {
            return (from x in db.Programs where x.ReportedPrograms.Count > 0 && x.ReportedPrograms.All(rp => rp.ReportStatus == "pending") select x).ToList();

        }

        public static List<ReportedProgram> getAllPendingReports(Program program)
        {
            return (from x in db.ReportedPrograms where x.ProgramID == program.ProgramID && x.ReportStatus == "pending" select x).ToList();
        }

        public static Program getProgramById(int programID)
        {
            return (from x in db.Programs where x.ProgramID == programID select x).FirstOrDefault();
        }

        public static ProgramChanges getProgramChangesById(int programID)
        {
            return (from x in db.ProgramChanges1 where x.ProgramID == programID select x).FirstOrDefault();
        }

        public static List<Program> getAllVerifiedPrograms(String query)
        {
            return (from x in db.Programs where x.Verified == true && x.ProgramTitle.Contains(query) select x).ToList();
        }

        public static List<Program> getAllVerifiedProgramsFromUserId(String query, int userId)
        {
            return (from x in db.Programs where x.Verified == true && x.ProgramTitle.Contains(query) && x.FundraiserID == userId select x).ToList();
        }

        public static List<Program> getAllPendingProgramsFromUserId(String query, int userId)
        {
            return (from x in db.Programs where x.Verified == false && x.ProgramTitle.Contains(query) && x.FundraiserID == userId select x).ToList();
        }

        public static List<Program> getAllPendingPrograms()
        {
            return (from x in db.Programs where x.Verified == false select x).ToList();
        }

        public static List<Program> getAllVerifiedSocialPrograms(String query)
        {
            return (from x in db.Programs where x.Verified == true && x.ProgramType.Equals("social") && x.ProgramTitle.Contains(query) select x).ToList();
        }

        public static List<Program> getAllVerifiedSocialProgramsFromUserId(String query, int userId)
        {
            return (from x in db.Programs where x.Verified == true && x.ProgramType.Equals("social") && x.ProgramTitle.Contains(query) && x.FundraiserID == userId select x).ToList();
        }

        public static List<Program> getAllPendingSocialProgramsFromUserId(String query, int userId)
        {
            return (from x in db.Programs where x.Verified == false && x.ProgramType.Equals("social") && x.ProgramTitle.Contains(query) && x.FundraiserID == userId select x).ToList();
        }

        public static List<Program> getAllPendingSocialPrograms()
        {
            return (from x in db.Programs where x.Verified == false && x.ProgramType.Equals("social") select x).ToList();
        }

        public static List<Program> getAllVerifiedProjectPrograms(String query)
        {
            return (from x in db.Programs where x.Verified == true && x.ProgramType.Equals("project") && x.ProgramTitle.Contains(query) select x).ToList();
        }

        public static List<Program> getAllVerifiedProjectProgramsFromUserId(String query, int userId)
        {
            return (from x in db.Programs where x.Verified == true && x.ProgramType.Equals("project") && x.ProgramTitle.Contains(query) && x.FundraiserID == userId select x).ToList();
        }

        public static List<Program> getAllPendingProjectProgramsFromUserId(String query, int userId)
        {
            return (from x in db.Programs where x.Verified == false && x.ProgramType.Equals("project") && x.ProgramTitle.Contains(query) && x.FundraiserID == userId select x).ToList();
        }

        public static List<Program> getAllPendingProjectPrograms()
        {
            return (from x in db.Programs where x.Verified == false && x.ProgramType.Equals("project") select x).ToList();
        }

        public static List<Donation> getTopDonationsByProgramId(int programID)
        {
            return (from x in db.Donations where x.Transaction.ProgramID == programID orderby x.Transaction.Amount descending select x).ToList();
        }

        public static List<ProgramChanges> getAllPendingChanges()
        {
            return (from x in db.ProgramChanges1 where x.isApproved == false select x).ToList();
        }
        public static void deleteProgram(int programId)
        {
            db.Programs.Remove(getProgramById(programId));
            db.SaveChanges();
        }

        public static int generateProgramID()
        {
            Program lastProgram = db.Programs.ToList().LastOrDefault();
            if (lastProgram == null)
            {
                return 1;
            }
            return lastProgram.ProgramID + 1;
        }

        public static int generateChangesProgramID()
        {
            ProgramChanges lastChanges = db.ProgramChanges1.ToList().LastOrDefault();
            if (lastChanges == null)
            {
                return 1;
            }
            return lastChanges.ProgramID + 1;
        }

        public static ProgramChanges createNewProgramChanges(int programId, String desc, int target, DateTime deadline, String image)
        {
            ProgramChanges changes = ProgramFactory.CreateProgramChanges(programId, desc, target, deadline, image);
            db.ProgramChanges1.Add(changes);
            db.SaveChanges();
            return changes;
        }

        public static Program createProgram(int userId, String topic, String title, String name, String beneficiary, String desc, String type, String location, int target, DateTime deadline, String programImg, String idImg)
        {
            Program program = ProgramFactory.CreateNewProgam(userId, topic, title, name, beneficiary, desc, type, location, target, deadline, programImg, idImg);
            db.Programs.Add(program);
            db.SaveChanges();
            return program;
        }

        public static void updateProgramRaised(int programId, int amount)
        {
            Program program = db.Programs.Find(programId);
            program.ProgramRaised += amount;
            db.SaveChanges();
        }

        public static void updateProgramWithdrawn(int programId, int amount)
        {
            Program program = db.Programs.Find(programId);
            program.Withdrawn += amount;
            db.SaveChanges();
        }

        public static int getActiveProgramCount()
        {
            return (from x in db.Programs where x.Verified == true && x.ProgramStatus.Equals("ongoing") select x).Count();
        }

    }
}