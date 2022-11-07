using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    private string _name = "Name";
    private string _bestName = "Best name";
    private int _bestScore;
    
    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public static GameManager GetInstance()
    {
        return _instance;
    }

    public string GetName()
    {
        return _name;
    }
    
    public string GetBestName()
    {
        return _bestName;
    }

    public void SetName(string newName)
    {
        _name = newName;
    }

    public int GetBestScore()
    {
        return _bestScore;
    }

    public void SetBestScore(int newScore)
    {
        if(newScore > _bestScore) _bestScore = newScore;
    }
    
    [System.Serializable]
    private class SavedData
    {
        public string name;
        public int bestScore;
    }

    public void SaveBestData()
    {
        _bestName = _name;
        var data = new SavedData { name = _name, bestScore = GetBestScore() };
        var json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        var path = Application.persistentDataPath + "/savefile.json";
        if (!File.Exists(path)) return;
        var json = File.ReadAllText(path);
        var data = JsonUtility.FromJson<SavedData>(json);
        _name = data.name;
        _bestScore = data.bestScore;
    }
}
