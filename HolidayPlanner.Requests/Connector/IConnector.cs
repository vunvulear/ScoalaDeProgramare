namespace HolidayPlanner.Requests
{
    public interface IConnector<in TMessage>
    {
        void Send(TMessage itemToSend);
    }
}