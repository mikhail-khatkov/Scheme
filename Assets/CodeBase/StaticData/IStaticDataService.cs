using System;
using CodeBase.Infrastructure.Services;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;

namespace CodeBase.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadStaticData();
        WindowConfig ForWindow(WindowId windowId);
        LevelStaticData ForLevel(string sceneKey);
        DeviceConfig ForDevice(DeviceTypeId deviceType);
    }
}