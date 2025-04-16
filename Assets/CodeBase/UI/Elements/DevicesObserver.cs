using System.Collections.Generic;
using System.Linq;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.StaticData.Device;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class DevicesObserver : MonoBehaviour
    {
        private IWindowService _windowService;
        private IPersistentProgressService _progressService;
        
        private readonly List<Device> _devices = new();
        private bool AllDevicesFilled => _devices.All(device => device.DeviceState >= DeviceState.Filled);

        private bool AllDevicesCorrect => _devices.All(device => device.transform.parent.GetComponent<DeviceSpawner>().CorrectDeviceTypes.Contains(device.DeviceTypeId));

        public void Construct(IWindowService windowService)
        {
            _windowService = windowService;
        }
        
        private void OnDestroy() => 
            CleanUp();

        public void Initialize()
        {
            _devices.AddRange(GetComponentsInChildren<Device>());
            SubscribeUpdates();
        }

        private void SubscribeUpdates()
        {
            foreach (var device in _devices) 
                device.StateChanged += OnDeviceStateChanged;
        }

        private void OnDeviceStateChanged()
        {
            if (AllDevicesFilled)
            {
                _windowService.Open(AllDevicesCorrect ? WindowId.WinWindow : WindowId.LoseWindow);
            }
        }

        private void CleanUp()
        {
            foreach (var device in _devices) 
                device.StateChanged -= OnDeviceStateChanged;
        }
    }
}