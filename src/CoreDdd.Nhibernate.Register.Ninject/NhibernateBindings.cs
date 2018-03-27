﻿using System;
using CoreDdd.Domain.Repositories;
using CoreDdd.Nhibernate.Repositories;
using CoreDdd.Nhibernate.UnitOfWorks;
using CoreDdd.UnitOfWorks;
using Ninject.Modules;
using Ninject.Syntax;

namespace CoreDdd.Nhibernate.Register.Ninject
{
    public class NhibernateBindings : NinjectModule
    {
        private static Func<IBindingWhenInNamedWithOrOnSyntax<
            NhibernateUnitOfWork>, IBindingWhenInNamedWithOrOnSyntax<NhibernateUnitOfWork>> _setUnitOfWorkLifeStyleFunc;

        public static void SetUnitOfWorkLifeStyle(
            Func<IBindingWhenInNamedWithOrOnSyntax<NhibernateUnitOfWork>, 
                 IBindingWhenInNamedWithOrOnSyntax<NhibernateUnitOfWork>> setLifeStyleFunc
            )
        {
            _setUnitOfWorkLifeStyleFunc = setLifeStyleFunc;
        }

        public override void Load()
        {
            if (_setUnitOfWorkLifeStyleFunc == null)
            {
                throw new Exception("First call NhibernateBindings.SetUnitOfWorkLifeStyle() to set unit of work lifestyle " +
                                    "(e.g. NhibernateBindings.SetUnitOfWorkLifeStyle(x => x.InRequestScope())");
            }

            Bind(typeof(IRepository<>)).To(typeof(NhibernateRepository<>)).InTransientScope();
            Bind(typeof(IRepository<,>)).To(typeof(NhibernateRepository<,>)).InTransientScope();
            _setUnitOfWorkLifeStyleFunc(Bind<IUnitOfWork, NhibernateUnitOfWork>().To<NhibernateUnitOfWork>());
        }
    }
}
