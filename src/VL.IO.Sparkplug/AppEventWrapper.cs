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
            return Observable.FromEvent<Func<SparkplugBase<Metric>.NodeBirthEventArgs, Task>, SparkplugBase<Metric>.NodeBirthEventArgs>(
                   conversion: action => x => { 
                       action(x); 
                       return Task.CompletedTask; 
                   },
                   addHandler: handler => instance.NodeBirthReceivedAsync += handler,
                   removeHandler: handler => instance.NodeBirthReceivedAsync -= handler);
        }

        public static IObservable<SparkplugBase<Metric>.NodeEventArgs> NodeDeathReceived(SparkplugApplication instance)
        {
            return Observable.FromEvent<Func<SparkplugBase<Metric>.NodeEventArgs, Task>, SparkplugBase<Metric>.NodeEventArgs>(
                   conversion: action => x => { 
                       action(x); 
                       return Task.CompletedTask; 
                   },
                   addHandler: handler => instance.NodeDeathReceivedAsync += handler,
                   removeHandler: handler => instance.NodeDeathReceivedAsync -= handler);
        }

        public static IObservable<SparkplugApplicationBase<Metric>.NodeDataEventArgs> NodeDataReceived(SparkplugApplication instance)
        {
            return Observable.FromEvent<Func<SparkplugApplicationBase<Metric>.NodeDataEventArgs, Task>, SparkplugApplicationBase<Metric>.NodeDataEventArgs>(
                   conversion: action => x => { action(x); return Task.CompletedTask; },
                   addHandler: handler => instance.NodeDataReceivedAsync += handler,
                   removeHandler: handler => instance.NodeDataReceivedAsync -= handler);
        }

        // Devices
        public static IObservable<SparkplugBase<Metric>.DeviceBirthEventArgs> DeviceBirthReceived(SparkplugApplication instance)
        {
            return Observable.FromEvent<Func<SparkplugBase<Metric>.DeviceBirthEventArgs, Task>, SparkplugBase<Metric>.DeviceBirthEventArgs>(
                   conversion: action => x => { 
                       action(x); 
                       return Task.CompletedTask; 
                   },
                   addHandler: handler => instance.DeviceBirthReceivedAsync += handler,
                   removeHandler: handler => instance.DeviceBirthReceivedAsync -= handler);
        }

        public static IObservable<SparkplugBase<Metric>.DeviceEventArgs> DeviceDeathReceived(SparkplugApplication instance)
        {
            return Observable.FromEvent<Func<SparkplugBase<Metric>.DeviceEventArgs, Task>, SparkplugBase<Metric>.DeviceEventArgs>(
                   conversion: action => x => { 
                       action(x); 
                       return Task.CompletedTask; 
                   },
                   addHandler: handler => instance.DeviceDeathReceivedAsync += handler,
                   removeHandler: handler => instance.DeviceDeathReceivedAsync -= handler);
        }

        public static IObservable<SparkplugApplicationBase<Metric>.DeviceDataEventArgs> DeviceDataReceived(SparkplugApplication instance)
        {
            return Observable.FromEvent<Func<SparkplugApplicationBase<Metric>.DeviceDataEventArgs, Task>, SparkplugApplicationBase<Metric>.DeviceDataEventArgs>(
                   conversion: action => x => { action(x); return Task.CompletedTask; },
                   addHandler: handler => instance.DeviceDataReceivedAsync += handler,
                   removeHandler: handler => instance.DeviceDataReceivedAsync -= handler);
        }

        public static IObservable<SparkplugApplicationBase<Metric>.DeviceDataEventArgs> MessagerReceived(SparkplugApplication instance)
        {
            return Observable.FromEvent<Func<SparkplugApplicationBase<Metric>.DeviceDataEventArgs, Task>, SparkplugApplicationBase<Metric>.DeviceDataEventArgs>(
                   conversion: action => x => { action(x); return Task.CompletedTask; },
                   addHandler: handler => instance.DeviceDataReceivedAsync += handler,
                   removeHandler: handler => instance.DeviceDataReceivedAsync -= handler);
        }
    }
}
