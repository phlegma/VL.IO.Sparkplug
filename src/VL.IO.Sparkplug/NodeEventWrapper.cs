using System;
using SparkplugNet.Core;
using SparkplugNet.VersionB;
using SparkplugNet.VersionB.Data;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using SparkplugNet.Core.Node;

namespace VL.IO.Sparkplug
{
    public class NodeEventWrapper
    {
        //Devices
        public static IObservable<SparkplugBase<Metric>.DeviceBirthEventArgs> DeviceBirthPublishing(SparkplugNode instance)
        {
            Subject<SparkplugBase<Metric>.DeviceBirthEventArgs> subject = new Subject<SparkplugBase<Metric>.DeviceBirthEventArgs>();
            instance.DeviceBirthPublishingAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        public static IObservable<SparkplugBase<Metric>.DeviceEventArgs> DeviceDeathPublishing(SparkplugNode instance)
        {
            Subject<SparkplugBase<Metric>.DeviceEventArgs> subject = new Subject<SparkplugBase<Metric>.DeviceEventArgs>();
            instance.DeviceDeathPublishingAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        public static IObservable<SparkplugNodeBase<Metric>.DeviceCommandEventArgs> DeviceCommandReceived(SparkplugNode instance)
        {
            Subject<SparkplugNodeBase<Metric>.DeviceCommandEventArgs> subject = new Subject<SparkplugNodeBase<Metric>.DeviceCommandEventArgs>();
            instance.DeviceCommandReceivedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        public static IObservable<SparkplugNodeBase<Metric>.NodeCommandEventArgs> NodeCommandReceived(SparkplugNode instance)
        {
            Subject<SparkplugNodeBase<Metric>.NodeCommandEventArgs> subject = new Subject<SparkplugNodeBase<Metric>.NodeCommandEventArgs>();
            instance.NodeCommandReceivedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        public static IObservable<SparkplugNodeBase<Metric>.StatusMessageEventArgs> StatusMessageReceived(SparkplugNode instance)
        {
            Subject<SparkplugNodeBase<Metric>.StatusMessageEventArgs> subject = new Subject<SparkplugNodeBase<Metric>.StatusMessageEventArgs>();
            instance.StatusMessageReceivedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }
    }
}
