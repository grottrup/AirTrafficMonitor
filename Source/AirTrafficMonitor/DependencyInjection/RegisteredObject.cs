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

        public RegisteredObject(Type typeToResolve, object instance)
        {
            TypeToResolve = typeToResolve;
            ConcreteType = instance.GetType();
            Instance = instance;
        }

        public void CreateInstance(params object[] args)
        {
            if (Instance == null || args.Length == 0) //rethink this
            {
                this.Instance = Activator.CreateInstance(this.ConcreteType, args);
            }
        }
    }
}