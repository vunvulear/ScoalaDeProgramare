namespace HolidayPlanner.Requests
{
    public interface IConnectorResolver
    {
        IConnector<TMessage> Resolve<TMessage>()
            where TMessage : class;
    }
}