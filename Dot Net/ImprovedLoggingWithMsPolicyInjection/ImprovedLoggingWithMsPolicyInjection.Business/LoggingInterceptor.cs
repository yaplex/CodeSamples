// Created at: 2013-03-04 2:25 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-04 3:28 PM

namespace ImprovedLoggingWithMsPolicyInjection.Business
{
    using System;
    using System.Collections.Specialized;
    using System.Reflection;
    using System.Text;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.Unity.InterceptionExtension;

    [ConfigurationElementType(typeof (CustomCallHandlerData))]
    public class LoggingInterceptor : ICallHandler
    {
        public LoggingInterceptor(NameValueCollection nameValueCollection)
        {
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            Console.WriteLine("Calling Mehtod: "
                              + input.MethodBase.DeclaringType.FullName + "." + input.MethodBase.Name +
                              "with parameters: " + PrintInputParameters(input.Inputs));

            IMethodReturn result = getNext()(input, getNext); // this is the actual call to our underleaing class

            Console.WriteLine("Leaving Method: " + input.MethodBase.DeclaringType.FullName + "." + input.MethodBase.Name +
                              "with return value: " + PringReturnValue(result));

            return result;
        }

        public int Order { get; set; }

        private string PringReturnValue(IMethodReturn result)
        {
            if (null == result.ReturnValue)
                return "null";

            return result.ReturnValue.ToString();
        }

        private static string PrintInputParameters(IParameterCollection parameters)
        {
            if (0 == parameters.Count)
            {
                return " without parameters ";
            }

            var parameterString = new StringBuilder();
            parameterString.Append("(");
            for (int i = 0; i < parameters.Count; i++)
            {
                ParameterInfo parameter = parameters.GetParameterInfo(i);

                parameterString.Append(parameter.Name + " = " + parameters[i]);
            }
            parameterString.Append(")");
            return parameterString.ToString();
        }
    }
}