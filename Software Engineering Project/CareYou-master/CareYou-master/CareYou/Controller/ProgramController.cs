using CareYou.DataClass;
using CareYou.Handler;
using CareYou.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CareYou.Controller
{
    public class ProgramController
    {
        public static List<Program> getProgramHistory(int identifier, int userID)
        {
            if(identifier == 1)
            {
                return ProgramHandler.getFirstProgram(userID);
            }else if(identifier == 2)
            {
                return ProgramHandler.getSecondAboveProgram(userID);
            }

            return null;
        }

        public static bool isOwner(int programID, int userID)
        {
            Program program = ProgramHandler.getProgramById(programID);
            if(program != null)
            {
                return program.User.UserID == userID;
            }

            return false;
        }

        public static Response<ProgramChanges> checkDesc(String desc)
        {
            if (desc == "")
            {
                return new Response<ProgramChanges>()
                {
                    Success = false,
                    Message = "Description cannot be empty",
                    Field = "desc",
                    Payload = null
                };
            }
            return new Response<ProgramChanges>()
            {
                Success = true,
                Message = "",
                Field = "desc",
                Payload = null
            };
        }

        public static Response<ProgramChanges> checkTarget(int target)
        {
            if (target <= 0)
            {
                return new Response<ProgramChanges>()
                {
                    Success = false,
                    Message = "Target is invalid",
                    Field = "target",
                    Payload = null
                };
            }
            return new Response<ProgramChanges>()
            {
                Success = true,
                Message = "",
                Field = "target",
                Payload = null
            };
        }

        public static Response<ProgramChanges> checkDeadline(String deadline)
        {
            if(!DateTime.TryParse(deadline, out DateTime result))
            {
                return new Response<ProgramChanges>()
                {
                    Success = false,
                    Message = "Invalid date format",
                    Field = "deadline",
                    Payload = null
                };
            }
            if (result < DateTime.Now)
            {
                return new Response<ProgramChanges>()
                {
                    Success = false,
                    Message = "Deadline must be greater than current date",
                    Field = "deadline",
                    Payload = null
                };
            }
            return new Response<ProgramChanges>()
            {
                Success = true,
                Message = "",
                Field = "deadline",
                Payload = null
            };
        }

        public static Response<ProgramChanges> checkConfirmation(bool confirmation)
        {
            if (!confirmation)
            {
                return new Response<ProgramChanges>()
                {
                    Success = false,
                    Message = "Please confirm the changes",
                    Field = "confirmation",
                    Payload = null
                };
            }
            return new Response<ProgramChanges>()
            {
                Success = true,
                Message = "",
                Field = "confirmation",
                Payload = null
            };
        }

        public static Response<ProgramChanges> checkFile(HttpPostedFile file)
        {
            if ((file.ContentLength == 0))
            {
                return new Response<ProgramChanges>()
                {
                    Success = false,
                    Message = "Please upload a file",
                    Field = "file",
                    Payload = null
                };
            }
            return new Response<ProgramChanges>()
            {
                Success = true,
                Message = "",
                Field = "file",
                Payload = null
            };
        }



        public static Response<ProgramChanges> createProgramChanges(bool confirmation, int programId, String desc, int target, String deadline, HttpPostedFile file)
        {
            Response<ProgramChanges> confirmationResponse = checkConfirmation(confirmation);
            Response<ProgramChanges> descResponse = checkDesc(desc);
            Response<ProgramChanges> targetResponse = checkTarget(target);
            Response<ProgramChanges> deadlineResponse = checkDeadline(deadline);
            Response<ProgramChanges> fileResponse = checkFile(file);
            if(confirmationResponse.Success && descResponse.Success && targetResponse.Success && deadlineResponse.Success && fileResponse.Success)
            {
                
                return ProgramHandler.createProgramChanges(programId, desc, target, Convert.ToDateTime(deadline), file);
            }
            
            if (!descResponse.Success)
            {
                return descResponse;
            }
            if (!targetResponse.Success)
            {
                return targetResponse;
            }
            if (!deadlineResponse.Success)
            {
                return deadlineResponse;
            }
            if (!fileResponse.Success)
            {
                return fileResponse;
            }
            return confirmationResponse;
        }

        public static Response<Program> checkTopic(String topic)
        {
            if (topic == "")
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Topic cannot be empty",
                    Field = "topic",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "topic",
                Payload = null
            };
        }

        public static Response<Program> checkTitle(String title)
        {
            if (title == "")
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Title cannot be empty",
                    Field = "title",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "title",
                Payload = null
            };
        }

        public static Response<Program> checkName(String name)
        {
            if (name == "")
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Name cannot be empty",
                    Field = "name",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "name",
                Payload = null
            };
        }

        public static Response<Program> checkBeneficiary(String beneficiary)
        {
            if (beneficiary == "")
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Beneficiary cannot be empty",
                    Field = "beneficiary",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "beneficiary",
                Payload = null
            };
        }

        public static Response<Program> checkDescP(String desc)
        {
            if (desc == "")
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Description cannot be empty",
                    Field = "desc",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "desc",
                Payload = null
            };
        }

        public static Response<Program> checkType(String type)
        {
            if( type == "")
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Please select a program type",
                    Field = "type",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "type",
                Payload = null
            };
        }

        public static Response<Program> checkLocation(String location)
        {
            if (location == "")
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Location cannot be empty",
                    Field = "location",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "location",
                Payload = null
            };
        }

        public static Response<Program> checkTargetP(int target)
        {
            if (target <= 0)
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Target is invalid",
                    Field = "target",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "target",
                Payload = null
            };
        }

        public static Response<Program> checkDeadlineP(String deadline)
        {
            if (!DateTime.TryParse(deadline, out DateTime result))
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Invalid date format",
                    Field = "deadline",
                    Payload = null
                };
            }
            if (result < DateTime.Now)
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Deadline must be greater than current date",
                    Field = "deadline",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "deadline",
                Payload = null
            };
        }

        public static Response<Program> checkConfirmationP(bool confirmation)
        {
            if (!confirmation)
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Please confirm the data",
                    Field = "confirmation",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "confirmation",
                Payload = null
            };
        }

        public static Response<Program> checkProgramImage(HttpPostedFile file)
        {
            if ((file.ContentLength == 0))
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Please upload a file",
                    Field = "programImage",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "programImage",
                Payload = null
            };
        }

        public static Response<Program> checkIDImage(HttpPostedFile file)
        {
            if (file.ContentLength == 0)
            {
                return new Response<Program>()
                {
                    Success = false,
                    Message = "Please upload a file",
                    Field = "IdImage",
                    Payload = null
                };
            }
            return new Response<Program>()
            {
                Success = true,
                Message = "",
                Field = "IdImage",
                Payload = null
            };
        }

        public static Response<Program> createProgram(int userId, String topic, String title, String name, String beneficiary, String desc, String type, String location, int target, String deadline, HttpPostedFile programImg, HttpPostedFile idImg, bool confirmation)
        {
            Response<Program> topicResponse = checkTopic(topic);
            Response<Program> titleResponse = checkTitle(title);
            Response<Program> nameResponse = checkName(name);
            Response<Program> beneficiaryResponse = checkBeneficiary(beneficiary);
            Response<Program> descResponse = checkDescP(desc);
            Response<Program> typeResponse = checkType(type);
            Response<Program> locationResponse = checkLocation(location);
            Response<Program> targetResponse = checkTargetP(target);
            Response<Program> deadlineResponse = checkDeadlineP(deadline);
            Response<Program> confirmationResponse = checkConfirmationP(confirmation);
            Response<Program> programImageResponse = checkProgramImage(programImg);
            Response<Program> idImageResponse = checkIDImage(idImg);
            if (topicResponse.Success && titleResponse.Success && nameResponse.Success && beneficiaryResponse.Success && descResponse.Success && typeResponse.Success && locationResponse.Success && targetResponse.Success && deadlineResponse.Success && confirmationResponse.Success && programImageResponse.Success && idImageResponse.Success)
            {
                return ProgramHandler.createProgram(userId, topic, title, name, beneficiary, desc, type, location, target, Convert.ToDateTime(deadline), programImg, idImg);
            }
            if(!topicResponse.Success)
            {
                return topicResponse;
            }
            if (!titleResponse.Success)
            {
                return titleResponse;
            }
            if (!nameResponse.Success)
            {
                return nameResponse;
            }
            if (!beneficiaryResponse.Success)
            {
                return beneficiaryResponse;
            }
            if (!descResponse.Success)
            {
                return descResponse;
            }
            if (!typeResponse.Success)
            {
                return typeResponse;
            }
            if(!locationResponse.Success)
            {
                return locationResponse;
            }
            if (!targetResponse.Success)
            {
                return targetResponse;
            }
            if (!deadlineResponse.Success)
            {
                return deadlineResponse;
            }
            if (!programImageResponse.Success)
            {
                return programImageResponse;
            }
            if (!idImageResponse.Success)
            {
                return idImageResponse;
            }
            return confirmationResponse;
        }
    }
}