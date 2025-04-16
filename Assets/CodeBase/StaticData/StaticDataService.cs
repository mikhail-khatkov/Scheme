using System.Collections.Generic;
using System.Linq;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using UnityEngine;

namespace CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private const string WindowsStaticDataPath = "StaticData/UI/WindowStaticData";
        private const string LevelsStaticDataPath = "StaticData/Levels";
        private const string DeviceStaticDataPath = "StaticData/Device/DeviceData";

        private Dictionary<WindowId, WindowConfig> _windowConfigs;
        private Dictionary<string, LevelStaticData> _levels;
        private Dictionary<DeviceTypeId, DeviceConfig> _deviceConfigs;

        public void LoadStaticData()
        {
            _windowConfigs = Resources.Load<WindowStaticData>(WindowsStaticDataPath)
                .Configs
                .ToDictionary(x => x.WindowId, x => x);
            
            _levels = Resources
                .LoadAll<LevelStaticData>(LevelsStaticDataPath)
                .ToDictionary(x => x.LevelKey, x => x);

            _deviceConfigs = Resources.Load<DeviceStaticData>(DeviceStaticDataPath)
                .Configs
                .ToDictionary(x => x.TypeId, x => x);
        }

        public WindowConfig ForWindow(WindowId windowId) =>
            _windowConfigs.TryGetValue(windowId, out WindowConfig windowConfig)
                ? windowConfig
                : null;

        public LevelStaticData ForLevel(string sceneKey) =>
            _levels.TryGetValue(sceneKey, out LevelStaticData staticData)
                ? staticData
                : null;

        public DeviceConfig ForDevice(DeviceTypeId deviceType) =>
            _deviceConfigs.TryGetValue(deviceType, out DeviceConfig deviceConfig)
                ? deviceConfig
                : null;
    }
}