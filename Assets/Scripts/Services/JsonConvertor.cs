using UnityEngine;

public class JsonConvertor : IJsonConvertor
{
    public T DeserializeObject<T>(string json) where T : class
    {
        return JsonUtility.FromJson<T>(json);
    }

    public string SerializeObject(object obj)
    {
        return JsonUtility.ToJson(obj);
    }
}