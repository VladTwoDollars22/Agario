using System;
using System.Collections.Generic;

namespace AgarioGame.Engine.Utilities
{
    public static class Dependency
    {
        private static Dictionary<Type, object> _instances = new();

        public static T Get<T>() where T : class
        {
            var type = typeof(T);
            return _instances.TryGetValue(type, out var instance) ? instance as T : null;
        }

        public static void Register<T>(T instance) where T : class
        {
            Register(typeof(T), instance);
        }

        public static void Register(Type type, object instance)
        {
            if (instance == null)
                throw new NullReferenceException($"Депенсі не може бути пустим");

            if (!_instances.TryAdd(type, instance))
                throw new ArgumentException($"{type.Name} вже зареєстровано");
        }

        public static void Unregister<T>() where T : class
        {
            _instances.Remove(typeof(T));
        }

        public static void Unregister(Type type)
        {
            _instances.Remove(type);
        }
    }
}
