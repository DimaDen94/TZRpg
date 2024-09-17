using UnityEngine;

public class UIFactory : IUIFactory
{
    private readonly IAssetProvider _assetProvider;

    public UIFactory(IAssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }

    public CharacterSelectorUI CreateCharacterSelectorUI()
    {
        var uiPrefab = _assetProvider.LoadAsset<CharacterSelectorUI>(UIPaths.CharacterSelectorUI);
        return Object.Instantiate(uiPrefab);
    }

    public GameUI CreateGameUI()
    {
        var uiPrefab = _assetProvider.LoadAsset<GameUI>(UIPaths.GameUI);
        return Object.Instantiate(uiPrefab);
    }
}



