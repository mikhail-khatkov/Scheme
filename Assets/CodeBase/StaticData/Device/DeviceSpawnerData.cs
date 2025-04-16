using System;
using System.Collections.Generic;
using CodeBase.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.StaticData.Device
{
    [Serializable]
    public class DeviceSpawnerData
    {
        public DeviceTypeId DeviceTypeId;
        public DeviceState DeviceState;
        public TransformData TransformData;
        public List<DeviceTypeId> CorrectDeviceTypes = new();

        public DeviceSpawnerData(DeviceTypeId deviceTypeId, DeviceState deviceState, TransformData transformData, List<DeviceTypeId> correctDeviceType)
        {
            DeviceTypeId = deviceTypeId;
            DeviceState = deviceState;
            TransformData = transformData;
            CorrectDeviceTypes = new List<DeviceTypeId>(correctDeviceType);
        }
    }
}