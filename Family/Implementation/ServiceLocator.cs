using Family.Interfaces;
using System;
using System.Collections.Generic;

namespace Family.Implementation
{
    public static class ServiceLocator
    {
        private static IDictionary<object, object> services = new Dictionary<object, object>();

        public static T GetService<T>()
        {
            object result;
            services.TryGetValue(typeof(T), out result);
            return result == null ? default(T) : (T)result;
        }

        public static void RegisterType<T>(T type)
        {
            services.Add(typeof(T), type);
        }
    }
}
