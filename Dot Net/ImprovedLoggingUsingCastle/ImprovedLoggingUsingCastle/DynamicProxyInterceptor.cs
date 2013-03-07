// Created at: 2013-03-07 12:09 PM
// 
// Modified by: Alexander Shapovalov (ashapovalov)
// Modified at: 2013-03-07 12:16 PM

namespace ImprovedLoggingUsingCastle
{
    using System;
    using System.Text;
    using Castle.DynamicProxy;
    using log4net;

    public class DynamicProxyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var logger = LogManager.GetLogger(invocation.TargetType);
            try
            {
                StringBuilder sb = null;
                if (logger.IsDebugEnabled)
                {
                    sb = new StringBuilder(invocation.TargetType.FullName)
                        .Append(".")
                        .Append(invocation.Method)
                        .Append("(");
                    for (int i = 0; i < invocation.Arguments.Length; i++)
                    {
                        if (i > 0)
                            sb.Append(", ");
                        sb.Append(invocation.Arguments[i]);
                    }
                    sb.Append(")");
                    logger.Debug(sb);
                }

                invocation.Proceed();
                if (logger.IsDebugEnabled)
                {
                    logger.Debug("Result of " + sb + " is: " + invocation.ReturnValue);
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                throw;
            }
        }
    }
}