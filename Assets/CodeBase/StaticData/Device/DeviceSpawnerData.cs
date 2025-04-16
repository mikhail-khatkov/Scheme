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
        public RectTransformData RectTransformData;
        public bool IsUIElement;
        public List<DeviceTypeId> CorrectDeviceTypes = new();

        public DeviceSpawnerData(DeviceTypeId deviceTypeId, DeviceState deviceState, Transform transform, List<DeviceTypeId> correctDeviceTypes)
        {
            DeviceTypeId = deviceTypeId;
            DeviceState = deviceState;
            CorrectDeviceTypes = new List<DeviceTypeId>(correctDeviceTypes);

            if (transform is RectTransform rectTransform)
            {
                RectTransformData = new RectTransformData(rectTransform);
                IsUIElement = true;
            }
            else
            {
                TransformData = transform.AsTransformData();
                IsUIElement = false;
            }
        }
    }

}