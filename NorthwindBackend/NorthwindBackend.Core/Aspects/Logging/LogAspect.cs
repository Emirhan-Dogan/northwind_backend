using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Loging;
using Core.CrossCuttingConcerns.Loging.Log4Net;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Logging
{
    public class LogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;

        public LogAspect(Type loggerServiceBaseType)
        {
            if (loggerServiceBaseType.BaseType != typeof(LoggerServiceBase))
            {
                throw new Exception("Wrong Type LogerServiceBaseType");
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerServiceBaseType);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }

        protected override void OnException(IInvocation invocation)
        {
            _loggerServiceBase.Error(GetLogDetail(invocation));
        }

        protected override void OnAfter(IInvocation invocation)
        {

        }

        protected override void OnSuccess(IInvocation invocation)
        {

        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter()
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }
            var LogDetail = new LogDetail()
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };

            return LogDetail;
        }
    }
}
