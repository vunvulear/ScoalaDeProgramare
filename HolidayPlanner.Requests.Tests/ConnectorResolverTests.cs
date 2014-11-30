using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HolidayPlanner.Requests.Tests
{
    [TestClass]
    public class ConnectorResolverTests
    {
        [TestMethod]
        public void Resolve_ValidateResolver_WithSuccess()
        {
            ConnectorResolver connectorResolver = new ConnectorResolver();
            IConnector<Email> emailConnector = connectorResolver.Resolve<Email>();

            Assert.IsNotNull(emailConnector);
            Assert.IsInstanceOfType(emailConnector,typeof(EmailConnector));
        }
    }
}