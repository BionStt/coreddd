using CoreDdd.Domain.Events;

namespace CoreDdd.Nhibernate.Tests.DomainEventsTests
{
    public class TestDomainEventHandler : IDomainEventHandler<TestDomainEvent>
    {
        public static bool DomainEventWasHandled { get; private set; }

        public void Handle(TestDomainEvent domainEvent)
        {
            DomainEventWasHandled = true;
        }

        public static void ResetDomainEventWasHandled()
        {
            DomainEventWasHandled = false;
        }
    }
}