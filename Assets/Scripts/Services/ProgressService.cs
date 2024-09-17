using System.IO;

public class ProgressService : IProgressService
{
    private readonly IJsonConvertor _jsonConvertor;
    private const string ProgressFilePath = "progress.json";
    private ProgressData _progressData;

    public ProgressService(IJsonConvertor jsonConvertor)
    {
        _jsonConvertor = jsonConvertor;
        LoadProgress();
    }

    public void SaveSelectedCharacterId(int characterId)
    {
        _progressData.CharacterId = characterId;
        SaveProgress();
    }

    public int GetSelectedCharacterId() => _progressData.CharacterId;

    private void LoadProgress()
    {
        if (File.Exists(ProgressFilePath))
        {
            string json = File.ReadAllText(ProgressFilePath);
            _progressData = _jsonConvertor.DeserializeObject<ProgressData>(json);
        }
        else
        {
            _progressData = new ProgressData();
        }
    }

    private void SaveProgress()
    {
        string json = _jsonConvertor.SerializeObject(_progressData);
        File.WriteAllText(ProgressFilePath, json);
    }
}
