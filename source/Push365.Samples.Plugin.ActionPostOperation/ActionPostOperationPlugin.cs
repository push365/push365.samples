using Microsoft.Xrm.Sdk;
using System;

namespace Push365.Samples.Plugin.ActionPostOperation
{
    public class ActionPostOperationPlugin : IPlugin
    {
        public void Execute(IServiceProvider serviceProvider)
        {
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));
            var tracingService = (ITracingService)serviceProvider.GetService(typeof(ITracingService));

            EntityReference target = null;
            EntityReference itemLookup = null;
            EntityReference systemuserLookup = null;
            DateTime actionedOn = DateTime.MinValue;
            string actionIdentifier = string.Empty;
            string notificationIdentifier = string.Empty;

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] != null)
            {
                target = (EntityReference)context.InputParameters["Target"];
            }

            if (context.InputParameters.Contains("SystemUserId") && context.InputParameters["SystemUserId"] != null)
            {
                systemuserLookup = (EntityReference)context.InputParameters["SystemUserId"];
            }

            if (context.InputParameters.Contains("ItemId") && context.InputParameters["ItemId"] != null)
            {
                itemLookup = (EntityReference)context.InputParameters["ItemId"];
            }

            if (context.InputParameters.Contains("ActionedOn") && context.InputParameters["ActionedOn"] != null)
            {
                actionedOn = Convert.ToDateTime(context.InputParameters["ActionedOn"]);
            }

            if (context.InputParameters.Contains("ActionIdentifier") && context.InputParameters["ActionIdentifier"] != null)
            {
                actionIdentifier = Convert.ToString(context.InputParameters["ActionIdentifier"]);
            }

            if (context.InputParameters.Contains("NotificationIdentity") && context.InputParameters["NotificationIdentity"] != null)
            {
                notificationIdentifier = Convert.ToString(context.InputParameters["NotificationIdentity"]);
            }

            /*
             * TODO :
             * Please implement your custom business logic here
             */
        }
    }
}
