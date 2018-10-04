using System;

namespace DependencyInjection
{
    /// <summary>
    /// https://timross.wordpress.com/2010/01/21/creating-a-simple-ioc-container/
    /// </summary>
    public class RegisteredObject
    {
        public Type TypeToResolve { get; }
        public Type ConcreteType { get; }
        public object Instance { get; private set; }

        public RegisteredObject(Type typeToResolve, Type concreteType)
        {
            TypeToResolve = typeToResolve;  
            ConcreteType = concreteType;
        }

        public void CreateInstance(params object[] args)
        {
           Instance = Activator.CreateInstance(ConcreteType, args);
        }
    }
}