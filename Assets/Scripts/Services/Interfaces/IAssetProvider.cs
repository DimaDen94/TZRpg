using UnityEngine;

public interface IAssetProvider
{
    T LoadAsset<T>(string assetPath) where T : Object;
}