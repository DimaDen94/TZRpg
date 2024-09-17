using UnityEngine;

public class AssetProvider : IAssetProvider
{
    public T LoadAsset<T>(string assetPath) where T : Object
    {
        return Resources.Load<T>(assetPath);
    }
}
