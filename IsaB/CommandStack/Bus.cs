using IsaB.CommandStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsaB.CommandStack
{
    public class Bus : IBus
    {
        private readonly Dictionary<Type, Type> SagaStarters =
        new Dictionary<Type, Type>();
        private readonly Dictionary<string, object> SagaInstances =
        new Dictionary<string, object>();
        public void RegisterSaga<TStartMessage, TSaga>()
        {
            SagaStarters.Add(typeof(TStartMessage), typeof(TSaga));
        }
        public void Send<T>(T message) where T : Message
        {
            // Publish the event
            if (message is IDomainEvent)
            {
                // Invoke all registered sagas and give each
                // a chance to handle the event.
                foreach (var saga in SagaInstances)
                {
                    var handler = (IHandles<T>)saga.Value;
                    if (handler != null)
                        handler.Handle(message);
                }
            }
            // Check if the message can start one of the registered sagas
            if (SagaStarters.ContainsKey(typeof(T)))
            {
                // Start the saga creating a new instance of the type
                var typeOfSaga = SagaStarters[typeof(T)];
                var instance = (IHandles<T>)Activator.CreateInstance(typeOfSaga);
                instance.Handle(message);
                // At this point the saga has been given an ID;
                // let's persist the instance to a (memory) dictionary for later use.
                var saga = (SagaBase<T>)instance;
                SagaInstances.Add(saga.ID, instance);
                return;
            }
            // The message doesn't start any saga.
            // Check if the message can be delivered to an existing saga instead
            if (SagaInstances.ContainsKey(message.ID))
            {
                var saga = (IHandles<T>)SagaInstances[message.ID];
                saga.Handle(message);
                // Saves saga back or remove if completed
                if (saga.IsComplete())
                    SagaInstances.Remove(message.ID);
                else
                    SagaInstances[message.ID] = saga;
            }
        }

        void IBus.Send<T>(T command)
        {
            throw new NotImplementedException();
        }

        public void RaiseEvent<T>(T @event) where T : DomainEvent
        {
            throw new NotImplementedException();
        }

        public void RegisterHandler<T>()
        {
            throw new NotImplementedException();
        }
    }
}