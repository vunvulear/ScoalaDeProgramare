namespace HolidayPlanner.Requests.Tests
{
    public class MockConnectorResolver : IConnectorResolver
    {
        public MockConnector MockConnector { get; private set; }

        public MockConnectorResolver()
        {
            MockConnector = new MockConnector();
        }

        public new IConnector<TMessage> Resolve<TMessage>()
            where TMessage : class
        {
            return (IConnector<TMessage>)MockConnector;
        }
    }
}