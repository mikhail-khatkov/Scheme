using System.Collections.Generic;
using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using CodeBase.Logic;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
    public interface IUIFactory : IService
    {
        void CreateUIRoot();
        void CreateMenuWindow(IWindowService windowService);
        void CreateGameplayWindow(LevelStaticData levelData, IWindowService windowService);
        WindowBase CreateWindow(WindowId windowId);
        void CreateDeviceSpawners(LevelStaticData levelData, Transform parent);
        void CreateDevice(DeviceSpawnerData deviceData, Transform parent);
        void CreateInventoryItems(LevelStaticData levelData, Transform parent);
        void Cleanup();
    }
}
