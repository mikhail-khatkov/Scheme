using System;

namespace CodeBase.StaticData.Device
{
    [Serializable]
    public class InventoryItemsData
    {
        public DeviceTypeId DeviceTypeId;
        public int Count;

        public InventoryItemsData(DeviceTypeId deviceTypeId, int count)
        {
            DeviceTypeId = deviceTypeId;
            Count = count;
        }
    }
}