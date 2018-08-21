using System;
using CoreDdd.Domain.Events;

namespace CoreDdd.Nhibernate.Tests.TestEntities
{
    public class TestDomainEventHandler : IDomainEventHandler<TestDomainEvent>
    {
        private readonly Action<TestDomainEvent> _onDomainEventHandled;

        public TestDomainEventHandler(Action<TestDomainEvent> onDomainEventHandled)
        {
            _onDomainEventHandled = onDomainEventHandled;
        }

        public void Handle(TestDomainEvent domainEvent)
        {
            _onDomainEventHandled(domainEvent);
        }
    }
}