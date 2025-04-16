using CodeBase.Data;
using Unity.VisualScripting;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
  public class AssetProvider : IAssetProvider
  {
    public GameObject Instantiate(string path, Vector3 at)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab, at, Quaternion.identity);
    }

    public GameObject Instantiate(string path, TransformData at, Transform parent)
    {
      var prefab = Resources.Load<GameObject>(path);
      GameObject gameObject = Object.Instantiate(prefab, at.Position.AsUnityVector(), at.Rotation.AsUnityQuaternion(),parent);
      gameObject.transform.localScale = at.LocalScale.AsUnityVector();

      return gameObject;
    }

    public T Instantiate<T>(string path) where T : Object
    {
      var prefab = Resources.Load<T>(path);
      return Object.Instantiate(prefab);
    }

    public GameObject Instantiate(string path, Transform parent)
    {
      var prefab = Resources.Load<GameObject>(path);
      return Object.Instantiate(prefab,parent);
    }
  }
}