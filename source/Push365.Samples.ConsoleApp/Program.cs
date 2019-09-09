using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Push365.Samples.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var username = "{REPLACE-YOUR-DYNAMICS365-USERNAME}";
                var password = "{REPLACE-YOUR-DYNAMICS365-PASSWORD}";
                var organizationName = "{REPLACE-YOUR-DYNAMICS365-ORGANIZATION-NAME}";
                var region = "{REPLACE-YOUR-DYNAMICS365-REGION}"; //like crm4 , crm11

                var connectionString = $"AuthType=Office365;Username={username}; Password={password};Url=https://{organizationName}.{region}.dynamics.com;";

                CrmServiceClient crmServiceClient = new CrmServiceClient(connectionString);

                SingleUser singleUser = new SingleUser(crmServiceClient);
                singleUser.Send();

                TeamMembers teamMembers = new TeamMembers(crmServiceClient);
                teamMembers.Send();
            }
            catch (FaultException<OrganizationServiceFault> fEX)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(fEX.ToString());
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Please press a key to exit");
            Console.ReadLine();
        }
    }
}
