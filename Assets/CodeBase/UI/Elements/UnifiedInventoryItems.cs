using CodeBase.StaticData.Device;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class UnifiedInventoryItems : MonoBehaviour
    {
        public DeviceTypeId DeviceTypeId;
        public TMP_Text CounterText;
        public int Count = 1;
        public Image Image;
        public Image CounterImage;
        
        public int ItemsCount
        {
            get => Count;
            set
            {
                Count = value;
                OnCountChanged();
            }
        }

        public void Initialize(DeviceConfig deviceConfig)
        {
            Image.sprite = deviceConfig.Sprite;
        }

        public void OnCountChanged()
        {
            CounterText.text = $"{ItemsCount}";
            CounterImage.gameObject.SetActive(ItemsCount > 1);
            
            if (ItemsCount <= 0)
                Destroy(gameObject);
        }

        public void Initialize(int itemsDataCount, DeviceConfig forDevice)
        {
            ItemsCount = itemsDataCount;
            DeviceTypeId = forDevice.TypeId;
            Image.sprite = forDevice.Sprite;
        }
    }
}