using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;

public class CharacterListEditor : EditorWindow
{
    private const string CharacterPath = "Assets/Resources/CharacterPrefabs";
    private CharacterList _characterList;

    [MenuItem("Tools/Update Character List")]
    private static void ShowWindow()
    {
        GetWindow<CharacterListEditor>("Update Character List");
    }

    private void OnGUI()
    {
        GUILayout.Label("Update Character List", EditorStyles.boldLabel);

        _characterList = (CharacterList)EditorGUILayout.ObjectField("Character List", _characterList, typeof(CharacterList), false);

        if (GUILayout.Button("Load Character Paths"))
        {
            LoadCharacterPaths();
        }
    }
    private void LoadCharacterPaths()
    {
        if (_characterList == null)
        {
            Debug.LogError("Character List is not assigned.");
            return;
        }

        string[] allPaths = Directory.GetFiles(CharacterPath, "*.prefab", SearchOption.TopDirectoryOnly);
        var characterDataList = allPaths.Select((path, index) => new CharacterData
        {
            id = index,
            path = Path.GetRelativePath("Assets/Resources", path)
                .Replace("\\", "/") 
                .Replace(".prefab", "")
        }).ToArray();

        _characterList.characters = characterDataList;
        EditorUtility.SetDirty(_characterList);
        AssetDatabase.SaveAssets();

        Debug.Log("Character paths updated.");
    }

}
