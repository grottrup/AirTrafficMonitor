using System;

namespace DependencyInjection
{
    public interface IContainer
    {
        void Register<TTypeToResolve, TConcrete>();
        TTypeToResolve Resolve<TTypeToResolve>();

    }
}