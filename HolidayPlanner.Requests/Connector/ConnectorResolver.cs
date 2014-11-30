using System;
using System.Collections.Generic;

namespace HolidayPlanner.Requests
{
    public class ConnectorResolver : IConnectorResolver
    {
        private readonly Dictionary<Type, Func<object>> connectorMapping;

        public ConnectorResolver()
        {
            connectorMapping = new Dictionary<Type, Func<object>>
            {
                {typeof (Email), () => new EmailConnector()}
            };
        }

        public IConnector<TMessage> Resolve<TMessage>()
            where TMessage : class
        {
            IConnector<TMessage> requestedConnector = (IConnector<TMessage>) connectorMapping[typeof (TMessage)].Invoke();

            return requestedConnector;
        }
    }
}