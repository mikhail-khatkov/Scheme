using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.StaticData.Device
{
    [CreateAssetMenu(fileName = "DeviceData", menuName = "StaticData/Device")]
    public class DeviceStaticData : ScriptableObject
    {
        public List<DeviceConfig> Configs = new ();
    }
}