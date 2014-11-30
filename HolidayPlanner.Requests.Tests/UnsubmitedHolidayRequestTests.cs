using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidayPlanner.Requests.Tests
{
    [TestClass]
    public class UnsubmitedHolidayRequestTests
    {
        [TestMethod]
        public void SubmitRequest_SendEmail_WithSuccess()
        {
            MockConnectorResolver connectorResolver = new MockConnectorResolver();
            UnsubmitedHolidayRequest holidayRequest = new UnsubmitedHolidayRequest(connectorResolver);

            holidayRequest.SubmitRequest();

            Assert.IsTrue(connectorResolver.MockConnector.SendMethodWasCalled);
        }
    }
}