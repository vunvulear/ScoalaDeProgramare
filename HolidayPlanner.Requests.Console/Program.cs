using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HolidayPlanner.Requests.Console
{
    internal class Program
    {
        private static IConnectorResolver connectorResolver = new MockEmailServerConnectorResolver(ManagerNotification, HRNotification, EmployeeNotification);

        private static void Main(string[] args)
        {

            RequestHoliday();

            System.Console.ReadKey();
        }

        private static void RequestHoliday()
        {
            UnsubmitedHolidayRequest holidayRequest = new UnsubmitedHolidayRequest(connectorResolver);
            holidayRequest.EmployeeEmail = "Jack@daniels.com";
            holidayRequest.EmployeeName = "Jack Daniels";
            holidayRequest.From = DateTime.UtcNow.AddDays(1);
            holidayRequest.To = DateTime.UtcNow.AddDays(20);

            System.Console.WriteLine("Employee: New request was send");
            holidayRequest.SubmitRequest();
        }

        private static void ManagerNotification(Email email)
        {
            NewEmployeeHolidayRequest request = new NewEmployeeHolidayRequest(email, connectorResolver);
            System.Console.WriteLine(string.Format("Manager: New Request from {0}", request.EmployeeName));

            if (ApproveRequest())
            {
                request.Approve();
                System.Console.WriteLine("Manager: Request Approved");
            }
            else
            {
                request.Reject();
                System.Console.WriteLine("Manager: Request Rejected");
            }

        }

        private static bool ApproveRequest()
        {
            Random random = new Random();
            bool approveRequest = Convert.ToBoolean(random.Next(0, 1));

            return approveRequest;
        }

        private static void HRNotification(Email email)
        {
            System.Console.WriteLine("HR: Approved holiday request received.");
            ApprovedHolidayRequest approvedHolidayRequest = new ApprovedHolidayRequest(email,connectorResolver);            
        }

          private static void EmployeeNotification(Email email)
        {
            System.Console.WriteLine("Employee: Sorry, the holiday request was rejected.");
            RejectedHolidayRequest rejectedHolidayRequest= new RejectedHolidayRequest(email,connectorResolver);            
        }
    }
}
