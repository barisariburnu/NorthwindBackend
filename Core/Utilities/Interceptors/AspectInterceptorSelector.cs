using Castle.DynamicProxy;
using Core.Aspects.Autofac.Exception;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttribues = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);

            classAttributes.AddRange(methodAttribues);
            classAttributes.Add(new ExceptionLogAspect(typeof(JsonFileLogger)));

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
