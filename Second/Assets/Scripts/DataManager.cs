using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

public class DataManager : MonoBehaviour
{    
    [SerializeField] private GameObject Player;
    [SerializeField] GameData gD = new GameData();
    private string dataLoc = "./GameData/PlayerInfo.txt";
    public void SaveIntoJson()
    {
        gD.PlayerPosition = Player.transform.position;
        string data = JsonUtility.ToJson(gD);
        File.WriteAllText(dataLoc, data);
        Debug.Log("Saved Data");
    }

    public void LoadDataFromJson()
    {
        string JsonData = File.ReadAllText(dataLoc);
        gD = JsonConvert.DeserializeObject<GameData>(JsonData);
        Player.transform.position = gD.PlayerPosition;
    }
}

[System.Serializable]
public class GameData {
    public Vector2 PlayerPosition;
    // Array of Object Carried
    // State of Game
}
