using CareYou.Model;
using CareYou.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Factory
{
    public class ProgramFactory
    {
        public static Program CreateNewProgam(int fundraiserId, String topic, String title, String fundraiserName, String beneficiary, String desc,  String type, String location, int target, DateTime deadline, String image, String fundraiserIdCard )
        {
            Program program = new Program();
            program.ProgramID = programRepo.generateProgramID();
            program.FundraiserID = fundraiserId;
            program.ProgramTitle = title;
            program.ProgramDesc = desc;
            program.ProgramStatus = "ongoing";
            program.ProgramTopic = topic;
            program.FundraiserName = fundraiserName;
            program.BeneficiaryName = beneficiary;
            program.ProgramType = type;
            program.ProgramLoc = location;
            program.ProgramTarget = target;
            program.ProgramRaised = 0;
            program.ProgramImage = image;
            program.FundraiserNationalID = fundraiserIdCard;
            program.StartDate = DateTime.Now;
            program.EndDate = deadline;
            program.Verified = false;
            program.Withdrawn = 0;
            
            return program;
        }

        public static ProgramChanges CreateProgramChanges(int programId, String desc, int target, DateTime deadline, String image)
        {
            ProgramChanges changes = new ProgramChanges();
            changes.ChangesID = programRepo.generateChangesProgramID();
            changes.ProgramID = programId;
            changes.ChangesDesc = desc;
            changes.ChangesTarget = target;
            changes.ChangesEndDate = deadline;
            changes.ChangesImage = image;
            changes.isApproved = false;
            changes.DateSubmitted = DateTime.Now;

            return changes;
        }
    }
}