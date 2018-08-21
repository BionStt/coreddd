﻿using Ninject;
using NUnit.Framework;
using Shouldly;

namespace CoreIoC.Ninject.Tests
{
    [TestFixture]
    public class when_resolving_service
    {
        private interface IServiceType {}
        protected class ServiceType : IServiceType { }

        private object _result;
        private StandardKernel _kernel;

        [SetUp]
        public void Context()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IServiceType>().To<ServiceType>();
            var ninjectContainer = new NinjectContainer(_kernel);

            _result = ninjectContainer.Resolve(typeof(IServiceType));
        }

        [Test]
        public void service_is_resolved()
        {
            _result.ShouldBeOfType<ServiceType>();
        }

        [TearDown]
        public void TearDown()
        {
            _kernel.Dispose();
        }
    }
}