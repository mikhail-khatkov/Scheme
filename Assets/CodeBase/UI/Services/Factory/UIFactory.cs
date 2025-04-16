using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.States;
using CodeBase.StaticData;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Elements;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public class UIFactory : IUIFactory
    {
        private Transform _uiRoot;
        
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;
        private readonly IPersistentProgressService _progressService;
        private readonly IGameStateMachine _stateMachine;
        private readonly ISaveLoadProgressService _saveLoadProgressService;

        public UIFactory(IAssetProvider assetProvider, IStaticDataService staticData,
            IPersistentProgressService progressService, IGameStateMachine stateMachine, ISaveLoadProgressService saveLoadProgressService)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
            _progressService = progressService;
            _stateMachine = stateMachine;
            _saveLoadProgressService = saveLoadProgressService;
        }

        public void CreateUIRoot() =>
            _uiRoot = _assetProvider.Instantiate<Transform>(AssetPath.UIRootPath);

        public void CreateMenuWindow(IWindowService windowService)
        {
            WindowBase window = CreateWindow(WindowId.Menu);

            foreach (OpenWindowButton button in window.GetComponentsInChildren<OpenWindowButton>())
                button.Construct(windowService);
        }

        public void CreateGameplayWindow(LevelStaticData levelData, IWindowService windowService)
        {
            WindowConfig config = _staticData.ForWindow(WindowId.Gameplay);
            GameplayWindow window = Object.Instantiate(config.Prefab, _uiRoot).GetComponent<GameplayWindow>();
            
            window.Construct(_progressService, _stateMachine, this, _saveLoadProgressService, windowService);
            window.Initialize(levelData);
        }

        public WindowBase CreateWindow(WindowId windowId)
        {
            WindowConfig config = _staticData.ForWindow(windowId);
            WindowBase window = Object.Instantiate(config.Prefab, _uiRoot);
            
            window.Construct(_progressService, _stateMachine, this, _saveLoadProgressService);

            return window;
        }

        public void CreateDeviceSpawners(LevelStaticData levelData, Transform parent)
        {
            foreach (DeviceSpawnerData spawnerData in levelData.DeviceSpawners)
            {
                DeviceSpawner spawner = _assetProvider.Instantiate(AssetPath.DeviceSpawnerPath, spawnerData.TransformData, parent).GetComponent<DeviceSpawner>();
                spawner.Construct(this);
                spawner.Initialize(spawnerData.DeviceTypeId, spawnerData.DeviceState, spawnerData.CorrectDeviceTypes);
                spawner.Spawn(spawnerData, spawner.transform);
            }
        }

        public void CreateDevice(DeviceSpawnerData spawnerData, Transform parent)
        {
            Device device = _assetProvider
                .Instantiate(AssetPath.DevicePath, parent)
                .GetComponent<Device>();

            device.Construct(_staticData);
            device.Initialize(spawnerData.DeviceTypeId, spawnerData.DeviceState);
        }

        public void CreateInventoryItems(LevelStaticData levelData, Transform parent)
        {
            foreach (InventoryItemsData itemsData in levelData.InventoryItems)
            {
                UnifiedInventoryItems items = _assetProvider
                    .Instantiate(AssetPath.UnifiedInventoryItemsPath, parent)
                    .GetComponent<UnifiedInventoryItems>();

                items.Initialize(itemsData.Count, _staticData.ForDevice(itemsData.DeviceTypeId));
            }
        }

        public void Cleanup()
        {
        }
    }
}