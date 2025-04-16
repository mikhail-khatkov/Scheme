using System.Linq;
using System.Xml;
using CodeBase.Data;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Logic;
using CodeBase.StaticData;
using CodeBase.StaticData.Device;
using CodeBase.StaticData.Levels;
using CodeBase.UI.Elements;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Editor
{
    [CustomEditor(typeof(LevelStaticData))]
    public class LevelStaticDataEditor : UnityEditor.Editor
    {
        private const string InitialPointTag = "InitialPoint";
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            LevelStaticData levelData = (LevelStaticData)target;

            if (GUILayout.Button("Collect"))
            {
                levelData.LevelKey = SceneManager.GetActiveScene().name;
                
                levelData.DeviceSpawners = FindObjectsOfType<DeviceSpawner>()
                    .Select(x => new DeviceSpawnerData(x.DeviceTypeId, x.DeviceState, x.transform.AsTransformData(),x.CorrectDeviceTypes))
                    .ToList();

                levelData.InventoryItems = FindObjectsOfType<UnifiedInventoryItems>()
                    .Select(x => new InventoryItemsData(x.DeviceTypeId, x.Count))
                    .ToList();
                
                levelData.ContentSprite = Resources.Load<Sprite>(AssetPath.ContentSprites+$"/{levelData.LevelKey}");
            }
            
            EditorUtility.SetDirty(target);
        }
    }
}