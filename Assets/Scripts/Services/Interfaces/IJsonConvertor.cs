
public interface IJsonConvertor
{
    T DeserializeObject<T>(string json) where T : class;
    string SerializeObject(object obj);
}
