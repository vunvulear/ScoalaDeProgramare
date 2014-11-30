using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidayPlanner.Requests.Tests
{
    [TestClass]
    public class NewEmployeeHolidayRequestTests
    {
        [TestMethod]
        public void Ctor_InitRequestInformation_WithSuccess()
        {
            Email holidayRequestEmail = CreateSampleEmail();

            NewEmployeeHolidayRequest request = new NewEmployeeHolidayRequest(holidayRequestEmail,null);
            
            Assert.AreEqual(holidayRequestEmail.Title,request.EmployeeName);
        }

        [TestMethod]
        public void Approve_SendEmail_WithSuccess()
        {
            Email originalEmail = CreateSampleEmail();
            MockConnectorResolver connectorResolver = new MockConnectorResolver();
            NewEmployeeHolidayRequest request = new NewEmployeeHolidayRequest(originalEmail, connectorResolver);
            
            request.Approve();

            Assert.IsTrue(connectorResolver.MockConnector.SendMethodWasCalled);
        }

        [TestMethod]
        public void Reject_SendEmail_WithSuccess()
        {
            Email originalEmail = CreateSampleEmail();
            MockConnectorResolver connectorResolver = new MockConnectorResolver();
            NewEmployeeHolidayRequest request = new NewEmployeeHolidayRequest(originalEmail, connectorResolver);
            
            request.Reject();

            Assert.IsTrue(connectorResolver.MockConnector.SendMethodWasCalled);
        }

        private Email CreateSampleEmail()
        {
            Email holidayRequestEmail = new Email()
            {
                Title = "Lufthansa sucks",
                Body = "Hello Nurse",
            };

            return holidayRequestEmail;
        }
    }


}