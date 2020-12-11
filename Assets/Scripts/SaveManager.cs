using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager

{

    [SerializeField]
    private GameData _PotionData = new GameData("0", "0");
    public GameData gameSaving;
    public void SaveIntoJson(string score, string time)
    {
        _PotionData.score = score;
        _PotionData.time = time;
        File.Delete(Application.dataPath + "/LastGame.json");
        string potion = JsonUtility.ToJson(_PotionData);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/LastGame.json", potion);
    }
    public void LoadData()
    {
        gameSaving = JsonUtility.FromJson<GameData>(File.ReadAllText(Application.persistentDataPath + "/LastGame.json"));
    }

    [System.Serializable]
    public class GameData
    {
        public string score;
        public string time;

        public GameData(string _score, string _time)
        {
            score = _score;
            time = _time;
        }
    }
}