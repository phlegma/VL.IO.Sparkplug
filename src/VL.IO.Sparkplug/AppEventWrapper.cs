using System;
using SparkplugNet.Core;
using SparkplugNet.Core.Application;
using SparkplugNet.Core.Node;
using SparkplugNet.VersionB;
using SparkplugNet.VersionB.Data;
using System.Threading.Tasks;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace VL.IO.Sparkplug
{
    public class AppEventWrapper
    {
        // Nodes
        public static IObservable<SparkplugBase<Metric>.NodeBirthEventArgs> NodeBirthReceived(SparkplugApplication instance)
        {
            Subject<SparkplugBase<Metric>.NodeBirthEventArgs> subject = new Subject<SparkplugBase<Metric>.NodeBirthEventArgs>();
            instance.NodeBirthReceivedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        public static IObservable<SparkplugBase<Metric>.NodeEventArgs> NodeDeathReceived(SparkplugApplication instance)
        {
            Subject<SparkplugBase<Metric>.NodeEventArgs> subject = new Subject<SparkplugBase<Metric>.NodeEventArgs>();
            instance.NodeDeathReceivedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        public static IObservable<SparkplugApplicationBase<Metric>.NodeDataEventArgs> NodeDataReceived(SparkplugApplication instance)
        {
            Subject<SparkplugApplicationBase<Metric>.NodeDataEventArgs> subject = new Subject<SparkplugApplicationBase<Metric>.NodeDataEventArgs>();
            instance.NodeDataReceivedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        // Devices
        public static IObservable<SparkplugBase<Metric>.DeviceBirthEventArgs> DeviceBirthReceived(SparkplugApplication instance)
        {
            Subject<SparkplugBase<Metric>.DeviceBirthEventArgs> subject = new Subject<SparkplugBase<Metric>.DeviceBirthEventArgs>();
            instance.DeviceBirthReceivedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        public static IObservable<SparkplugBase<Metric>.DeviceEventArgs> DeviceDeathReceived(SparkplugApplication instance)
        {
            Subject<SparkplugBase<Metric>.DeviceEventArgs> subject = new Subject<SparkplugBase<Metric>.DeviceEventArgs>();
            instance.DeviceDeathReceivedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }

        public static IObservable<SparkplugApplicationBase<Metric>.DeviceDataEventArgs> DeviceDataReceived(SparkplugApplication instance)
        {
            Subject<SparkplugApplicationBase<Metric>.DeviceDataEventArgs> subject = new Subject<SparkplugApplicationBase<Metric>.DeviceDataEventArgs>();
            instance.DeviceDataReceivedAsync += args =>
            {
                subject.OnNext(args);
                return Task.CompletedTask;
            };
            return subject.AsObservable();
        }
    }
}
