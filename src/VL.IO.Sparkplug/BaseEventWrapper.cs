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
            Subject<SparkplugBase<Metric>.SparkplugEventArgs> subject = new Subject<SparkplugBase<Metric>.SparkplugEventArgs>();
            instance.ConnectedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        public static IObservable<SparkplugBase<Metric>.SparkplugEventArgs> Disconnected(SparkplugBase<Metric> instance)
        {
            Subject<SparkplugBase<Metric>.SparkplugEventArgs> subject = new Subject<SparkplugBase<Metric>.SparkplugEventArgs>();
            instance.DisconnectedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

    }
}
