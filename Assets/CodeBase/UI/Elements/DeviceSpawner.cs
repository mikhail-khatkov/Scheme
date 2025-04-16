using System.Collections.Generic;
using CodeBase.StaticData.Device;
using CodeBase.UI.Services.Factory;
using UnityEngine;

namespace CodeBase.UI.Elements
{
    public class DeviceSpawner : MonoBehaviour
    {
        public DeviceTypeId DeviceTypeId;
        public DeviceState DeviceState;
        public List<DeviceTypeId> CorrectDeviceTypes = new();

        private IUIFactory _uiFactory;

        public void Construct(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void Initialize(DeviceTypeId deviceTypeId, DeviceState deviceState, List<DeviceTypeId> correctDeviceTypes)
        {
            DeviceTypeId = deviceTypeId;
            DeviceState = deviceState;
            CorrectDeviceTypes = new List<DeviceTypeId>(correctDeviceTypes);
        }
        
        public void Spawn(DeviceSpawnerData deviceData, Transform parent)
        {
            _uiFactory.CreateDevice(deviceData, parent);
        }
    }
}