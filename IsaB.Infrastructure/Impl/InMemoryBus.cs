using System;
using System.Collections.Generic;
using System.Linq;
using LightInject;

namespace IsaB.Infrastructure.Impl
{
    public class InMemoryBus : IBus
    {
        public ServiceContainer Container {get; private set;}

        private  IDictionary<Type, Type> registeredSagas = new Dictionary<Type, Type>();
        private  IList<Type> registeredHandlers = new List<Type>();

        public InMemoryBus(ServiceContainer container)
        {
            if(container==null)
            {
                throw new ArgumentNullException("container");
            }
            Container = container;
        }

        void IBus.RegisterSaga<TStartMessage, TSaga>()
        {
            registeredSagas.Add(typeof(TStartMessage), typeof(TSaga));
        }

        void IBus.RegisterHandler<T>()
        {
            registeredHandlers.Add(typeof(T));
        }

        void _Send<T>(T message) where T : Message
        {
            BootRegisteredSagas(message);
            DeliverMessageToAlreadyRunningSagas(message);
            DeliverMessageToRegisteredHandlers(message);
        }

        private void DeliverMessageToRegisteredHandlers<T>(T message)
        {
            //Type messageType = message.GetType();
            //var openInterface = typeof(IHandleMessage<>);
            //var closedInterface = openInterface.MakeGenericType(messageType);
            //var handlersToNotify = from h in registeredHandlers
            //                     where closedInterface.IsAssignableFrom(h)
            //                     select h;
            //foreach(var h in handlersToNotify)
            //{
            //    dynamic handlerInstance = Container.Resolve(h);
            //    handlerInstance.Handle((dynamic)message);
            //}
        }

        private void BootRegisteredSagas<T>(T message) where T: Message
        {
            // Check if the message can start one of the registered sagas
            if (registeredSagas.ContainsKey(typeof(T)))
            {
                // Start the saga creating a new instance of the type
                var typeOfSaga = registeredSagas[typeof(T)];
                var instance = (IAmStartedBy<T>)Container.GetInstance(typeOfSaga);
                instance.Handle(message);
            }
        }

        private void DeliverMessageToAlreadyRunningSagas<T>(T message)
        {
            //Type messageType = message.GetType();
            //var openInterface = typeof(IHandleMessage<>);
            //var closedInterface = openInterface.MakeGenericType(messageType);
            //var sagasToNotify = from s in registeredSagas.Values
            //                     where closedInterface.IsAssignableFrom(s)
            //                     select s;
            //foreach (var s in sagasToNotify)
            //{
            //    dynamic sagaInstance = Container.Resolve(s);
            //    sagaInstance.Handle((dynamic)message);
            //}
        }

        void IBus.Send<T>(T command)
        {
            this._Send(command);
        }

        //void IBus.RaiseEvent<T>(T @event)
        //{
        //    EventStore.Save(@event);
        //    this._Send(@event);
        //}
    }
}
