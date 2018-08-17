using System;
using CoreDdd.Domain.Events;
using CoreDdd.Nhibernate.Tests.TestEntities;
using CoreIoC;
using CoreUtils.Storages;
using NUnit.Framework;
using Shouldly;

namespace CoreDdd.Nhibernate.Tests.DomainEventsTests
{
    [TestFixture]
    public class when_registering_delayed_domain_events_with_domain_events_not_initialized_with_domain_event_handler_factory
    {
        [Test]
        public void raising_delayed_domain_event_throws_not_initialized()
        {
            _simulateDomainEventsNotInitialized();
            _resetDelayedDomainEventHandlingItemsStorage();

            
            var ex = Should.Throw<InvalidOperationException>(() => new TestEntityWithDomainEvent().BehaviouralMethodWithRaisingDomainEvent());

            ex.Message.ToLower().ShouldContain("DomainEvents.InitializeWithDelayedDomainEventHandling");

            
            void _resetDelayedDomainEventHandlingItemsStorage()
            {
                IoC.Resolve<IStorage<DelayedDomainEventHandlingItems>>().Set(null);
            }

            void _simulateDomainEventsNotInitialized()
            {
                DomainEvents.InitializeWithDelayedDomainEventHandling(domainEventHandlerFactory: null, storageFactory: IoC.Resolve<IStorageFactory>());
            }
        }
    }
}