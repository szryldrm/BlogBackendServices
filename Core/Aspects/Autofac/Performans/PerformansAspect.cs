using System;
using System.Collections.Generic;
using System.Diagnostics;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;

namespace Core.Aspects.Autofac.Performans
{
    public class PerformansAspect : MethodInterception
    {
        private LoggerServiceBase _loggerServiceBase;
        private int _inverval;
        private Stopwatch _stopwatch;

        public PerformansAspect(Type loggerService, int inverval)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
            {
                throw new SystemException(AspectMessages.WRONG_LOGGER_TYPE);
            }

            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
            _inverval = inverval;
            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.TotalSeconds > _inverval)
            {
                LogDetailWithPerformance logDetailWithPerformance = GetLogDetail(invocation);
                logDetailWithPerformance.Interval = (int)_stopwatch.Elapsed.TotalSeconds;
                _loggerServiceBase.Warn(logDetailWithPerformance);
            }
            _stopwatch.Reset();


        }

        private LogDetailWithPerformance GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }

            var logDetailWithPerformance = new LogDetailWithPerformance
            {
                MethodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"),
                LogParameters = logParameters,
                DateTime = DateTime.Now
            };

            return logDetailWithPerformance;
        }
    }
}