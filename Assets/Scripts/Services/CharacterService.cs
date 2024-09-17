using UnityEngine;

public class CharacterService : ICharacterService
{
    private readonly IAssetProvider _assetProvider;
    private readonly IProgressService _progressService;
    private CharacterList _characterList;
    private readonly string _characterListPath = "ScriptableObjects/CharacterList";

    public CharacterService(IAssetProvider assetProvider, IProgressService progressService)
    {
        _assetProvider = assetProvider;
        _progressService = progressService;
    }

    public void LoadResources() =>
        _characterList = _assetProvider.LoadAsset<CharacterList>(_characterListPath);

    public CharacterData GetRandomCharacter(Transform parent = null)
    {
        if (_characterList == null)
        {
            Debug.LogError("CharacterList is not loaded. Call LoadResources() first.");
            return null;
        }

        int randomIndex = Random.Range(0, _characterList.characters.Length);
        return _characterList.characters[randomIndex];
    }

    public CharacterData GetSelectedCharacter(Transform parent = null)
    {
        int selectedCharacterId = _progressService.GetSelectedCharacterId();
        if (selectedCharacterId < 0 || selectedCharacterId >= _characterList.characters.Length)
        {
            Debug.LogError("Selected character ID is out of range.");
            return null;
        }

        return _characterList.characters[selectedCharacterId];
    }
}
