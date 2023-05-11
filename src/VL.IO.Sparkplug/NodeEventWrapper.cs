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
            return Observable.FromEvent<Func<SparkplugBase<Metric>.DeviceBirthEventArgs, Task>, SparkplugBase<Metric>.DeviceBirthEventArgs>(
                    conversion: action => x => { action(x); return Task.CompletedTask; },
                    addHandler: handler => instance.DeviceBirthPublishingAsync += handler,
                    removeHandler: handler => instance.DeviceBirthPublishingAsync -= handler);
        }

        public static IObservable<SparkplugBase<Metric>.DeviceEventArgs> DeviceDeathPublishing(SparkplugNode instance)
        {
            return Observable.FromEvent<Func<SparkplugBase<Metric>.DeviceEventArgs, Task>, SparkplugBase<Metric>.DeviceEventArgs>(
                    conversion: action => x => { action(x); return Task.CompletedTask; },
                    addHandler: handler => instance.DeviceDeathPublishingAsync += handler,
                    removeHandler: handler => instance.DeviceDeathPublishingAsync -= handler);
        }

        public static IObservable<SparkplugNodeBase<Metric>.DeviceCommandEventArgs> DeviceCommandReceived(SparkplugNode instance)
        {
            return Observable.FromEvent<Func<SparkplugNodeBase<Metric>.DeviceCommandEventArgs, Task>, SparkplugNodeBase<Metric>.DeviceCommandEventArgs>(
                    conversion: action => x => { action(x); return Task.CompletedTask; },
                    addHandler: handler => instance.DeviceCommandReceivedAsync += handler,
                    removeHandler: handler => instance.DeviceCommandReceivedAsync -= handler);
        }

        public static IObservable<SparkplugNodeBase<Metric>.NodeCommandEventArgs> NodeCommandReceived(SparkplugNode instance)
        {
            return Observable.FromEvent<Func<SparkplugNodeBase<Metric>.NodeCommandEventArgs, Task>, SparkplugNodeBase<Metric>.NodeCommandEventArgs>(
                    conversion: action => x => { action(x); return Task.CompletedTask; },
                    addHandler: handler => instance.NodeCommandReceivedAsync += handler,
                    removeHandler: handler => instance.NodeCommandReceivedAsync -= handler);
        }

        public static IObservable<SparkplugNodeBase<Metric>.StatusMessageEventArgs> StatusMessageReceived(SparkplugNode instance)
        {
            return Observable.FromEvent<Func<SparkplugNodeBase<Metric>.StatusMessageEventArgs, Task>, SparkplugNodeBase<Metric>.StatusMessageEventArgs>(
                    conversion: action => x => { action(x); return Task.CompletedTask; },
                    addHandler: handler => instance.StatusMessageReceivedAsync += handler,
                    removeHandler: handler => instance.StatusMessageReceivedAsync -= handler);
        }
    }
}
