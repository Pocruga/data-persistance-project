using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string PlayerName { get; set; }
    private int Highscore { get; set; }
    private string HighscorePlayerName { get; set; }

    // ensure the highscore is loaded on instantiating the singleton
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadHighscore();
            DontDestroyOnLoad(gameObject);
        }
    }

    // provide highscore text formatted for the app
    public String GetHighscoreText() 
    {
        if (Highscore == 0)
            return "No Highscore!";
        return string.Format("Highscore : {0} : {1}", HighscorePlayerName, Highscore); 
    }

    // check the score and persist on new highscore
    public void CheckAndPersistHighscore(int score)
    {
        if(Highscore < score) { 
            HighscorePlayerName = PlayerName;
            Highscore = score; 
            SaveHighscore();
        }
    }

    // read highscore data from file
    private void LoadHighscore() 
    {
        if(File.Exists(GetFilename()))
        {
            HighscoreData data = JsonUtility.FromJson<HighscoreData>(File.ReadAllText(GetFilename()));
            if(data != null)
            {
                HighscorePlayerName = data.playerName;
                Highscore = data.score;
            }
        }
    }

    // store highscore data to file
    private void SaveHighscore()
    {
        HighscoreData data = new HighscoreData() { playerName = HighscorePlayerName, score = Highscore };
        File.WriteAllText(GetFilename(), JsonUtility.ToJson(data));
    }

    private string GetFilename() { 
        return Application.persistentDataPath + "/highscore.json";
    }

    [Serializable]
    class HighscoreData
    {
        public string playerName;
        public int score;
    }
}
