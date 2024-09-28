using CareYou.DataClass;
using CareYou.Model;
using CareYou.Repository;
using CareYou.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace CareYou.Handler
{
    public class ProgramHandler
    {
        public static List<Program> getFirstProgram(int userID)
        {
            return programRepo.getProgramsByUserID(userID).ToList();
        }

        public static String getReportReason(ReportedProgram report)
        {
            String reason = "";
            if (report.ScamFundraise)
            {
                reason += "Scam Fundraise, ";
            }
            if (report.FraudFundraise)
            {
                reason += "Fraud Fundraise, ";
            }
            if (report.ThirdpartyBeneficiary)
            {
                reason += "ThirdpartyBeneficiary, ";
            }
            if (report.OtherReason != null)
            {
                reason += report.OtherReason;
            }
            return reason;
        }
        public static List<dynamic> getAllPendingReports(Program program)
        {
            List<ReportedProgram> reports = programRepo.getAllPendingReports(program);
            List<dynamic> reportDetails = new List<dynamic>();
            foreach (ReportedProgram report in reports)
            {
                String reason = getReportReason(report);
                dynamic reportDetail = new
                {
                    ReportID = report.ReportID,
                    ReportReason = reason
                };
                reportDetails.Add(reportDetail);
            }
            return reportDetails;
        }

        public static bool isWithdrawn(int programID)
        {
            Program program = programRepo.getProgramById(programID);
            return program.Withdrawn > 0;
        }

        public static List<Program> getSecondAboveProgram(int userID)
        {
            return programRepo.getProgramsByUserID(userID).Skip(1).ToList();
        }

        public static Program getProgramById(int programID)
        {
            return programRepo.getProgramById(programID);
        }

        public static ProgramChanges getProgramChangesById(int programID)
        {
            return programRepo.getProgramChangesById(programID);
        }

        public static void acceptProgram(int programID)
        {
            programRepo.acceptProgram(programID);
        }

        public static void deleteProgramChanges(int programID)
        {
            programRepo.deleteProgramChanges(programID);
        }

        public static void acceptProgramChanges(int programID)
        {
            programRepo.acceptProgramChanges(programID);
        }

        public static List<dynamic> getAllProgramsWithReports()
        {
            List<Program> programList = programRepo.getAllProgramsWithReports();
            List<dynamic> programDetails = new List<dynamic>();
            foreach (Program program in programList)
            {
                int reportCount = programRepo.getAllPendingReports(program).Count;
                dynamic ProgramDetail = new
                {
                    ProgramTitle = program.ProgramTitle,
                    ProgramID = program.ProgramID,
                    ReportCount = reportCount
                };
                programDetails.Add(ProgramDetail);
            }
            return programDetails;
        }

        public static List<dynamic> getAllPrograms(String programType, String query)
        {
            List<Program> programs =null;
            if(programType == "project")
            {
                programs = programRepo.getAllVerifiedProjectPrograms(query);
            }
            else if(programType == "social")
            {
                programs = programRepo.getAllVerifiedSocialPrograms(query);
            }
            else
            {
                programs = programRepo.getAllVerifiedPrograms(query);
            }
            
            List<dynamic> programDetails = new List<dynamic>();
            foreach(Program program in programs)
            {
                double Progress = getProgramProgress(program.ProgramID);
                String startDate = program.StartDate.ToString("d MMMM yyyy");

                dynamic programDetail = new
                {
                    ProgramID = program.ProgramID,
                    ProgramTitle = program.ProgramTitle,
                    ProgramImage = program.ProgramImage,
                    FundraiserName = program.FundraiserName,
                    ProgramType = program.ProgramType,
                    ProgramRaised = program.ProgramRaised,
                    Progress = Progress,
                    DateCreated = startDate
                };

                programDetails.Add(programDetail);
            }
            return programDetails;
        }

        public static List<dynamic> getAllVerifiedProgramsFromUserId(String programType, String query, int userId)
        {
            List<Program> programs = null;
            if (programType == "project")
            {
                programs = programRepo.getAllVerifiedProjectProgramsFromUserId(query, userId);
            }
            else if (programType == "social")
            {
                programs = programRepo.getAllVerifiedSocialProgramsFromUserId(query, userId);
            }
            else
            {
                programs = programRepo.getAllVerifiedProgramsFromUserId(query, userId);
            }

            List<dynamic> programDetails = new List<dynamic>();
            foreach (Program program in programs)
            {
                double Progress = getProgramProgress(program.ProgramID);
                String startDate = program.StartDate.ToString("d MMMM yyyy");

                dynamic programDetail = new
                {
                    ProgramID = program.ProgramID,
                    ProgramTitle = program.ProgramTitle,
                    ProgramImage = program.ProgramImage,
                    FundraiserName = program.FundraiserName,
                    ProgramType = program.ProgramType,
                    ProgramRaised = program.ProgramRaised,
                    Progress = Progress,
                    DateCreated = startDate
                };

                programDetails.Add(programDetail);
            }
            return programDetails;
        }

        public static List<dynamic> getAllPendingProgramsFromUserId(String programType, String query, int userId)
        {
            List<Program> programs = null;
            if (programType == "project")
            {
                programs = programRepo.getAllPendingProjectProgramsFromUserId(query, userId);
            }
            else if (programType == "social")
            {
                programs = programRepo.getAllPendingSocialProgramsFromUserId(query, userId);
            }
            else
            {
                programs = programRepo.getAllPendingProgramsFromUserId(query, userId);
            }

            List<dynamic> programDetails = new List<dynamic>();
            foreach (Program program in programs)
            {
                double Progress = getProgramProgress(program.ProgramID);
                String startDate = program.StartDate.ToString("d MMMM yyyy");

                dynamic programDetail = new
                {
                    ProgramID = program.ProgramID,
                    ProgramTitle = program.ProgramTitle,
                    ProgramImage = program.ProgramImage,
                    FundraiserName = program.FundraiserName,
                    ProgramType = program.ProgramType,
                    ProgramRaised = program.ProgramRaised,
                    Progress = Progress,
                    DateCreated = startDate
                };

                programDetails.Add(programDetail);
            }
            return programDetails;
        }

        public static List<dynamic> getAllPendingPrograms(String type)
        {
            List<Program> programs = null;
            List<ProgramChanges> changes = null;
            if (type == "new")
            {
                programs = programRepo.getAllPendingPrograms();
            }
            else if (type == "edit")
            {
                changes = programRepo.getAllPendingChanges();
            }
            else
            {
                programs = programRepo.getAllPendingPrograms();
                changes = programRepo.getAllPendingChanges();
            }

            List<dynamic> programDetails = new List<dynamic>();
            if(programs != null)
            {
                foreach (Program program in programs)
                {

                    dynamic programDetail = new
                    {
                        ProgramID = program.ProgramID,
                        ProgramTitle = program.ProgramTitle,
                        Type = "new"
                    };

                    programDetails.Add(programDetail);
                }
            }
            if(changes != null)
            {
                foreach (ProgramChanges program in changes)
                {

                    dynamic programDetail = new
                    {
                        ProgramID = program.ProgramID,
                        ProgramTitle = program.Program.ProgramTitle,
                        Type = "edit"
                    };

                    programDetails.Add(programDetail);
                }
            }
            
            return programDetails;
        }



        public static Double getProgramProgress(int programID)
        {
            Program program = programRepo.getProgramById(programID);
            double Progress = (double)program.ProgramRaised / (double)program.ProgramTarget * 100;
            if (Progress > 100) Progress = 100;
            return Math.Round(Progress);
        }
        public static List<dynamic> getFiveFirstSocialProgramsForHome()
        {
            var programs = programRepo.getAllVerifiedSocialPrograms("").Take(5).ToList();
            List<dynamic> programDetails = new List<dynamic>();

            foreach (var program in programs)
            {
                double Progress = getProgramProgress(program.ProgramID);
                dynamic programDetail = new
                {
                    ProgramID = program.ProgramID,
                    ProgramTitle = program.ProgramTitle,
                    ProgramDesc = program.ProgramDesc,
                    ProgramImage = program.ProgramImage,
                    FundraiserName = program.FundraiserName,
                    ProgramType = program.ProgramType,
                    ProgramRaised = program.ProgramRaised,
                    Progress = Progress
                };

                programDetails.Add(programDetail);
            }

            return programDetails;
        }

        public static List<dynamic> getFiveFirstProjectProgramsForHome()
        {
            var programs = programRepo.getAllVerifiedProjectPrograms("").Take(5).ToList();
            List<dynamic> programDetails = new List<dynamic>();

            foreach (var program in programs)
            {
                double Progress = getProgramProgress(program.ProgramID);
                dynamic programDetail = new
                {
                    ProgramID = program.ProgramID,
                    ProgramTitle = program.ProgramTitle,
                    ProgramDesc = program.ProgramDesc,
                    ProgramImage = program.ProgramImage,
                    FundraiserName = program.FundraiserName,
                    ProgramType = program.ProgramType,
                    ProgramRaised = program.ProgramRaised,
                    Progress = Progress
                };

                programDetails.Add(programDetail);
            }

            return programDetails;
        }

        private static String CalculateRelativeTime(DateTime commentTime)
        {
            var timeSpan = DateTime.Now - commentTime;

            if (timeSpan <= TimeSpan.FromSeconds(60))
                return "now";
            if (timeSpan <= TimeSpan.FromMinutes(60))
                return $"{timeSpan.Minutes} minutes ago";
            if (timeSpan <= TimeSpan.FromHours(24))
                return $"{timeSpan.Hours} hours ago";
            if (timeSpan <= TimeSpan.FromDays(30))
                return $"{timeSpan.Days} days ago";
            if (timeSpan <= TimeSpan.FromDays(365))
                return $"{timeSpan.Days / 30} months ago";
            return $"{timeSpan.Days / 365} years ago";
        }

        public static String getProgramCreatedDate(int programId)
        {
            Program program = programRepo.getProgramById(programId);
            return "Created " + CalculateRelativeTime(program.StartDate);
        }

        public static List<dynamic> getAllComments(int programId)
        {
            List<Transaction> transactions = transactionRepo.getDonationsByProgramId(programId);
            List<dynamic> comments = new List<dynamic>();
            foreach(Transaction tr in transactions)
            {
                if(tr.Donation.Comment == null || tr.Donation.Comment == "")
                {
                    continue;
                }
                else
                {
                    String CommentTime = CalculateRelativeTime(tr.TransactionDate);
                    if (tr.Donation.isAnonymous)
                    {
                        dynamic comment = new
                        {
                            UserID = tr.User.UserID,
                            UserName = "Anonymous",
                            ProfilePicture = "ProfileDefault.png",
                            Amount = tr.Amount,
                            Comment = tr.Donation.Comment,
                            CommentTime = CommentTime
                        };
                        comments.Add(comment);
                    }
                    else
                    {
                        dynamic comment = new
                        {
                            UserID = tr.User.UserID,
                            UserName = tr.User.UserName,
                            ProfilePicture = tr.User.ProfilePicture,
                            Amount = tr.Amount,
                            Comment = tr.Donation.Comment,
                            CommentTime = CommentTime
                        };
                        comments.Add(comment);
                    }  
                }
                
            }
            return comments;
        }
        public static int getDonationsCount(int programId)
        {
            return transactionRepo.getDonationsByProgramId(programId).Count;
        }

        public static List<dynamic> get3TopDonations(int programId)
        {
            List<Donation> donations = programRepo.getTopDonationsByProgramId(programId).Take(3).ToList();
            List<dynamic> topDonations = new List<dynamic>();
            foreach(Donation donation in donations)
            {
                if (donation.isAnonymous)
                {
                    dynamic topDonation = new
                    {
                        UserID = donation.Transaction.User.UserID,
                        UserName = "Anonymous",
                        ProfilePicture = "ProfileDefault.png",
                        Amount = donation.Transaction.Amount
                    };
                    topDonations.Add(topDonation);
                }
                else
                {
                    dynamic topDonation = new
                    {
                        UserID = donation.Transaction.User.UserID,
                        UserName = donation.Transaction.User.UserName,
                        ProfilePicture = donation.Transaction.User.ProfilePicture,
                        Amount = donation.Transaction.Amount
                    };
                    topDonations.Add(topDonation);
                }
                
            }
            return topDonations;
        }

        public static void deleteProgram(int programId)
        {
            programRepo.deleteProgram(programId);
        }

        public static Response<ProgramChanges> createProgramChanges(int programId, String desc, int target, DateTime deadline, HttpPostedFile file)
        {
            String programImageLoc = UploadFile(file, "~/Assets/Program/");
            ProgramChanges changes = programRepo.createNewProgramChanges(programId, desc, target, deadline, programImageLoc);
            file.SaveAs(HttpContext.Current.Server.MapPath("~/Assets/Program/") + file.FileName);
            return new Response<ProgramChanges>()
            {
                Success = true,
                Message = "",
                Field = "changes",
                Payload = changes
            };
        }

        public static Response<Program> createProgram(int userId, String topic, String title, String name, String beneficiary, String desc, String type, String location, int target, DateTime deadline, HttpPostedFile programImg, HttpPostedFile idImg)
        {
            String programImageLoc = UploadFile(programImg, "~/Assets/Program/");
            String idImageLoc = UploadFile(idImg, "~/Assets/Program/IDCard/");
            Program program = programRepo.createProgram(userId, topic, title, name, beneficiary, desc, type, location, target, deadline, programImageLoc, idImageLoc);
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "program",
                Payload = program
            };
        }

        public static String UploadFile(HttpPostedFile file, String path)
        {
                string uploadFolder = HttpContext.Current.Server.MapPath(path);
                string fileName = file.FileName;
                string filePath = Path.Combine(uploadFolder, fileName);

            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }
            // Check if file with same name exists
            if (File.Exists(filePath))
                {
                    string fileExtension = Path.GetExtension(fileName);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    int fileIndex = 1;

                    // Generate a unique file name
                    while (File.Exists(filePath))
                    {
                        fileName = $"{fileNameWithoutExtension}_{fileIndex}{fileExtension}";
                        filePath = Path.Combine(uploadFolder, fileName);
                        fileIndex++;
                    }
                }

                // Save the file with the unique name
                file.SaveAs(filePath);
                return fileName;
        }

        public static int GetActiveProgramCount()
        {
            return programRepo.getActiveProgramCount();
        }

    }
}