// Created at: 2013-03-07 12:08 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-07 12:08 PM
namespace ImprovedLoggingUsingCastle
{
    using System;
    using System.Linq;
    using Castle.DynamicProxy;
    using StructureMap;
    using StructureMap.Interceptors;

    public class StructureMapInterceptor : TypeInterceptor
    {
        private readonly ProxyGenerator _proxy = new ProxyGenerator();

        public object Process(object target, IContext context)
        {
            return _proxy.CreateInterfaceProxyWithTargetInterface(target.GetType().GetInterfaces().First(),
                                                                  target.GetType().GetInterfaces(), target,
                                                                  new DynamicProxyInterceptor());


        }

        public bool MatchesType(Type type)
        {
            // add extra logic there if required
            return true;
        }
    }
}