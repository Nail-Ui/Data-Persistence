using System;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string _playerName;
    public string _bestPlayerName;
    public int _bestScore;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadBestData();
    }

    public void SetUserName(string playerName)
    {
        _playerName = playerName;
    }
    // public void SetBestPlayerName(string bestPlayerName)
    // {
    //     _bestPlayerName = bestPlayerName;
    // }
    // public void SetBestScore(int bestScore)
    // {
    //     _bestScore = bestScore;
    // }
    
    //[System.Serializable] is needed to tell JsonUtility it's a class which can be serialized, which means. It can be transformed to Json format.
    [System.Serializable]
    class SaveData
    {
        public string _bestPlayerName;
        public int _bestScore;
    }

    public void SaveBestData(string bestPlayer, int bestScore)
    {
        SaveData data = new SaveData();
        data._bestPlayerName = bestPlayer;
        data._bestScore = bestScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

        //Bellekte de güncelle
        _bestPlayerName = bestPlayer;
        _bestScore = bestScore;
    }
    public void LoadBestData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            _bestPlayerName = data._bestPlayerName;
            _bestScore = data._bestScore;
        }
    }

}
