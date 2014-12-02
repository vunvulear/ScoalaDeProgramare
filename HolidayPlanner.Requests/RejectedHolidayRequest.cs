using System;

namespace HolidayPlanner.Requests
{
    public class RejectedHolidayRequest : HolidayRequest
    {
        public RejectedHolidayRequest(Email email, IConnectorResolver connectorResolver)
            : base(connectorResolver)
        {
            SetRequestInformation(email);
        }

        private void SetRequestInformation(Email email)
        {
            // parse the email content and retrieves holiday request information
            EmployeeName = email.Title;
            EmployeeEmail = "EmployeeEmail";
            ManagerEmail = "ManagerEmail";
            From = DateTime.Now.AddDays(3);
            To = From.AddDays(7);
        }
    }
}