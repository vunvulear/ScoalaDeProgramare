using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidayPlanner.Requests.Tests
{
    [TestClass]
    public class EmailConnectorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Send_WithNullEmail_ThrowArgumentNullException()
        {
            EmailConnector emailConnector = new EmailConnector();
            emailConnector.Send(null);
        }
    }
}
