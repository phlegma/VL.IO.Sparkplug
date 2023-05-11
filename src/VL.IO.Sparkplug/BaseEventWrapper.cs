using System;
using SparkplugNet.Core;
using SparkplugNet.Core.Node;
using SparkplugNet.VersionB;
using SparkplugNet.VersionB.Data;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace VL.IO.Sparkplug
{
    public class BaseEventWrapper
    {
        //Base
        public static IObservable<SparkplugBase<Metric>.SparkplugEventArgs> Connected(SparkplugBase<Metric> instance)
        {
            return Observable.FromEvent<Func<SparkplugBase<Metric>.SparkplugEventArgs, Task>, SparkplugBase<Metric>.SparkplugEventArgs>(
                    conversion: action => x => { action(x); return Task.CompletedTask; },
                    addHandler: handler => instance.ConnectedAsync += handler,
                    removeHandler: handler => instance.ConnectedAsync -= handler);
        }

        public static IObservable<SparkplugBase<Metric>.SparkplugEventArgs> Disconnected(SparkplugBase<Metric> instance)
        {
            return Observable.FromEvent<Func<SparkplugBase<Metric>.SparkplugEventArgs, Task>, SparkplugBase<Metric>.SparkplugEventArgs>(
                    conversion: action => x => { action(x); return Task.CompletedTask; },
                    addHandler: handler => instance.DisconnectedAsync += handler,
                    removeHandler: handler => instance.DisconnectedAsync -= handler);
        }

    }
}
