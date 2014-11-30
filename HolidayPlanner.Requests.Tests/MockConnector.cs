namespace HolidayPlanner.Requests.Tests
{
    public class MockConnector : IConnector<Email>
    {
        public bool SendMethodWasCalled { get; private set; }

        public void Send(Email itemToSend)
        {
            SendMethodWasCalled = true;
        }
    }
}