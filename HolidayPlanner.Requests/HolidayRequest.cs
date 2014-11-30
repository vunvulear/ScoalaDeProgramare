using System;

namespace HolidayPlanner.Requests
{
    public abstract class HolidayRequest
    {
        protected readonly IConnectorResolver connectorResolver;

        protected HolidayRequest(IConnectorResolver connectorResolver)
        {
            this.connectorResolver = connectorResolver;
        }

        public string EmployeeName { get; set; }

        public string EmployeeEmail { get; set; }

        public string ManagerEmail { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        protected void SendEmail(Email email)
        {
            IConnector<Email> emailConnector = connectorResolver.Resolve<Email>();
            emailConnector.Send(email);
        }

    }
}
