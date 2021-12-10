using System;
using System.IO;
using UnityEngine;
using UnityEngine.Serialization;

public class SaveScript : MonoBehaviour
{
    public string objectJson;
    public GameObject dt;

    public void SaveData(int score, int coins)
    {
        SavingHighscore data = dt.GetComponent<SavingHighscore>();
        data.highScore = score;
        data.coinCollectedInOneRun = coins;

        objectJson = JsonUtility.ToJson(data, true);
        File.WriteAllText("data.json", objectJson);
    }

    public void LoadData()
    {
        if (File.Exists("data.json"))
        {
            objectJson = File.ReadAllText("data.json");
            SavingHighscore temp = JsonUtility.FromJson<SavingHighscore>(objectJson);
            dt.GetComponent<SavingHighscore>().highScore = temp.highScore;
            dt.GetComponent<SavingHighscore>().coinCollectedInOneRun = temp.coinCollectedInOneRun;
        }
        else
        {
            Debug.Log("File does not exists");
            File.Create("data.json");
            SaveData(0, 0);
        }
        
    }
}