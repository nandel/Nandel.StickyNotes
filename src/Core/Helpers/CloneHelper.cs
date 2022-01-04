using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace Nandel.StikyNotes.Core.Helpers
{
    public static class CloneHelper
    {
        /// <summary>
        /// Cache das funções de clone
        /// </summary>
        private static readonly ConcurrentDictionary<Type, MethodInfo> _memberwiseCloneMethods = new ConcurrentDictionary<Type, MethodInfo>();

        /// <summary>
        /// Clona um objeto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static T Clone<T>(this T instance)
        {
            var objectType = instance.GetType();
            if (!_memberwiseCloneMethods.ContainsKey(objectType))
            {
                var methodInfo = objectType.GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
                if (methodInfo is null)
                {
                    throw new InvalidOperationException();
                }
                
                _memberwiseCloneMethods.TryAdd(objectType, methodInfo);
                
                return (T) methodInfo.Invoke(instance, null); // como o add pode falhar, já chamamos aqui o método
            }

            
            return (T) _memberwiseCloneMethods[objectType].Invoke(instance, null);
        }
    }
}