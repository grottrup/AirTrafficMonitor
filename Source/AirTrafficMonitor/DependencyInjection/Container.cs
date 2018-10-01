using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInjection
{
    /// <summary>
    /// https://timross.wordpress.com/2010/01/21/creating-a-simple-ioc-container/
    /// </summary>
    public class Container : IContainer
    {
        private readonly IList<RegisteredObject> _registeredObjects = new List<RegisteredObject>();

        public void Register<TTypeToResolve, TConcrete>()
        {
            _registeredObjects.Add(new RegisteredObject(typeof (TTypeToResolve), typeof (TConcrete)));
        }

        public void Register<TTypeToResolve>(object instance)
        {
            _registeredObjects.Add(new RegisteredObject(typeof (TTypeToResolve), instance));
        }

        public TTypeToResolve Resolve<TTypeToResolve>()
        {
            return (TTypeToResolve) ResolveObject(typeof (TTypeToResolve));
        }

        private object ResolveObject(Type typeToResolve)
        {
            var registeredObject = _registeredObjects.FirstOrDefault(o => o.TypeToResolve == typeToResolve);
            if (registeredObject == null)
            {
                throw new TypeNotRegisteredException(string.Format(
                    "The type {0} has not been registered", typeToResolve.Name));
            }
            return GetInstance(registeredObject);
        }

        private object GetInstance(RegisteredObject registeredObject)
        {
            if (registeredObject.Instance == null)
            {
                var parameters = ResolveConstructorParameters(registeredObject);
                registeredObject.CreateInstance(parameters.ToArray());
            }
            return registeredObject.Instance;
        }

        private IEnumerable<object> ResolveConstructorParameters(RegisteredObject registeredObject)
        {
            var constructorInfo = registeredObject.ConcreteType.GetConstructors().First();
            foreach (var parameter in constructorInfo.GetParameters())
            {
                yield return ResolveObject(parameter.ParameterType);
            }
        }
    }
}