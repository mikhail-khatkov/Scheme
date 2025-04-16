using System.Collections.Generic;
using CodeBase.Logic;
using CodeBase.StaticData.Device;
using UnityEngine;
using UnityEngine.Serialization;

namespace CodeBase.StaticData.Levels
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "StaticData/Level")]
    public class LevelStaticData : ScriptableObject
    {
        public string LevelKey;
        [FormerlySerializedAs("EnemySpawners")] public List<DeviceSpawnerData> DeviceSpawners = new();
        public List<InventoryItemsData> InventoryItems = new();
        public Sprite ContentSprite;
    }
}