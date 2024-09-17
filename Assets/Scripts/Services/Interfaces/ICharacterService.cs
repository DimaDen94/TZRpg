using UnityEngine;

public interface ICharacterService
{
    CharacterData GetRandomCharacter(Transform parent = null);
    CharacterData GetSelectedCharacter(Transform parent = null);
    void LoadResources();
}
