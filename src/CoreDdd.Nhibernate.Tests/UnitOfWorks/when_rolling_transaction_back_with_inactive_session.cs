using FakeItEasy;
using NUnit.Framework;

namespace CoreDdd.Nhibernate.Tests.UnitOfWorks
{
    [TestFixture]
    public class when_rolling_transaction_back_with_inactive_session : NhibernateUnitOfWorkWithCommittedTransactionSetup
    {
        [SetUp]
        public override void Context()
        {
            base.Context();
           
            UnitOfWork.Rollback();
        }

        [Test]
        public void rollback_was_not_called_on_transaction()
        {
            A.CallTo(() => Transaction.Rollback()).MustNotHaveHappened();
        }
    }
}