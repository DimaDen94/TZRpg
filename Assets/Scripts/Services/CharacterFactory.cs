using UnityEngine;

public class CharacterFactory : ICharacterFactory
{
    private readonly IAssetProvider _assetProvider;

    public CharacterFactory(IAssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }

    public GameObject CreateCharacter(string path)
    {
        GameObject characterPrefab = _assetProvider.LoadAsset<GameObject>(path);
        return Object.Instantiate(characterPrefab);
    }

    public GameObject CreateCharacter(string path, Transform parent)
    {
        GameObject characterPrefab = _assetProvider.LoadAsset<GameObject>(path);
        return Object.Instantiate(characterPrefab, parent);
    }
}



