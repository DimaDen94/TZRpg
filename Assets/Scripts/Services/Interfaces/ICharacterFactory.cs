using UnityEngine;

public interface ICharacterFactory
{
    GameObject CreateCharacter(string path);
    GameObject CreateCharacter(string path, Transform parent);
}



