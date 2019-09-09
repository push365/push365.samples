using System;

namespace Push365.Samples.API.Messages.Request
{
    public class Push365IntegrationRequest
    {
        public Guid NotificationId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid SystemUserId { get; set; }
        public string ActionIdentifier { get; set; }
        public double ActionTime { get; set; }
        public Dynamics365ItemData Dynamics365ItemData { get; set; }
    }
}