using CodeBase.Data;
using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path, TransformData at, Transform parent);
        T Instantiate<T>(string path) where T : Object;
        GameObject Instantiate(string path, Transform parent);
    }
}