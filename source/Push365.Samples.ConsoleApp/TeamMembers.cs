using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Push365.Samples.ConsoleApp
{
    public class TeamMembers
    {
        CrmServiceClient _crmServiceClient;

        public TeamMembers(CrmServiceClient crmServiceClient)
        {
            _crmServiceClient = crmServiceClient;
        }

        public void Send()
        {
            OrganizationRequest request = new OrganizationRequest("push365_NotificationSendToTeamRequest");

            //INFO : Required parameters
            request["Target"] = new EntityReference("team", Guid.Parse("{YOUR-RECORD-ID}"));
            request["Title"] = "Notification to Team Members";
            request["Message"] = "This notification sent from Dynamics 365 Custom Action";

            //INFO : Optional parameters
            //request["IncludeAdministrator"] = true;
            //request["ContinueOnError"] = true;
            //request["IsInteractionRequired"] = true;
            //request["IsHighPriority"] = true;
            //request["Icon"] = new EntityReference("push365_image", Guid.Parse("{YOUR-RECORD-ID}"));
            //request["Image"] = new EntityReference("push365_image", Guid.Parse("{YOUR-RECORD-ID}"));

            //INFO : You can only use one of following options (URL, Open Desktop Application or Actions)
            //request["OpenDesktopApplication"] = true;
            //request["Url"] = "https://www.push365.co";
            //request["Action01"] = new EntityReference("push365_action", Guid.Parse("{YOUR-RECORD-ID}"));
            //request["Action02"] = new EntityReference("push365_action", Guid.Parse("{YOUR-RECORD-ID}"));

            //INFO : You can specify any entity to "Item" parameter.
            //request["Item"] = new EntityReference("push365_image", Guid.Parse("{YOUR-RECORD-ID}"));
            //request["Item"] = new EntityReference("contact", Guid.Parse("{YOUR-RECORD-ID}"));
            //request["Item"] = new EntityReference("new_customentity", Guid.Parse("{YOUR-RECORD-ID}"));

            var response = (OrganizationResponse)_crmServiceClient.Execute(request);

            var isFaulted = (bool)response["IsFaulted"];

            if (!isFaulted)
            {
                var notificationIdList = response["NotificationIdList"].ToString();

                if (!string.IsNullOrEmpty(notificationIdList))
                {
                    var splitted = notificationIdList.Split(',');

                    foreach (var item in splitted)
                    {
                        Console.WriteLine($"Notification Id : {item}");
                    }
                }
            }
        }
    }
}
