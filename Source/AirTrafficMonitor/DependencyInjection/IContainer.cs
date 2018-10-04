using System;

namespace DependencyInjection
{
    public interface IContainer
    {
        void Register<TTypeToResolve, TConcrete>();
        void Register<TTypeToResolve>(object instance);
        TTypeToResolve Resolve<TTypeToResolve>();

    }
}