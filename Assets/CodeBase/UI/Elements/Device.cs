using System;
using CodeBase.StaticData;
using CodeBase.StaticData.Device;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CodeBase.UI.Elements
{
    public class Device : MonoBehaviour, IDropHandler
    {
        public GameObject Background;
        public Image Icon;

        public event Action StateChanged;

        private IStaticDataService _staticData;

        private DeviceState _deviceState;

        private DeviceTypeId _deviceTypeId;

        public DeviceState DeviceState
        {
            get => _deviceState;
            set
            {
                _deviceState = value;
                OnStateChanged();
            }
        }

        public DeviceTypeId DeviceTypeId
        {
            get => _deviceTypeId;
            set
            {
                _deviceTypeId = value;
                OnTypeChanged();
            }
        }

        public void Construct(IStaticDataService staticData)
        {
            _staticData = staticData;
        }

        public void Initialize(DeviceTypeId deviceTypeId, DeviceState deviceState)
        {
            DeviceTypeId = deviceTypeId;
            DeviceState = deviceState;
        }

        void OnStateChanged()
        {
            Icon.gameObject.SetActive(_deviceState >= DeviceState.Filled);
            Background.SetActive(_deviceState != DeviceState.Сonnected);

            StateChanged?.Invoke();
        }

        private void OnTypeChanged()
        {
            Icon.sprite = _staticData.ForDevice(DeviceTypeId).Sprite;
        }

        public void OnDrop(PointerEventData eventData)
        {
            if (eventData.pointerDrag != null && DeviceState < DeviceState.Filled)
            {
                UnifiedInventoryItems items = eventData.pointerDrag.GetComponent<UnifiedInventoryItems>();
                
                DeviceTypeId = items.DeviceTypeId;
                DeviceState = DeviceState.Filled;

                items.ItemsCount--;
            }
        }
    }
}