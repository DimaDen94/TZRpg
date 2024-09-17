using UnityEngine;

[CreateAssetMenu(fileName = "CharacterList", menuName = "Character/CharacterList", order = 51)]
public class CharacterList : ScriptableObject
{
    public CharacterData[] characters;
}
