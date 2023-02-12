using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Performance
{
    public class PerformanceAspect : MethodInterception
    {
        private int _interval;
        private Stopwatch _stopwatch;

        public PerformanceAspect(int interval)
        {
            _interval = interval;

            _stopwatch = ServiceTool.ServiceProvider.GetService<Stopwatch>();
        }

        protected override void OnAfter(IInvocation invocation)
        {
            if (_stopwatch.Elapsed.Seconds > _interval) // mail gönderebilir vs vs 
            {
                Debug.WriteLine($"Performance : {invocation.Method.DeclaringType.Name}.{invocation.Method.Name} ==> {_stopwatch.Elapsed.TotalSeconds} milisecond.");
            }
            _stopwatch.Reset();
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _stopwatch.Start();
        }

    }
}
