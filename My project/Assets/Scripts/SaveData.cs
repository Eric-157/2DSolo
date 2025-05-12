using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

//Using: https://www.youtube.com/watch?v=pVXEUtMy_Hc

public class SaveData : MonoBehaviour
{
    public PlayerData playerData = new PlayerData();

    private void Awake()
    {
        if(!File.Exists(Application.persistentDataPath + "/PlayerData.json"))
        {
            SaveToJson();
        }
        else{
            LoadFromJson();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            SaveToJson();
        }
    }

    public void SaveToJson()
    {
        string stringPlayerData = JsonUtility.ToJson(playerData);
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        Debug.Log(filePath);
        System.IO.File.WriteAllText(filePath, stringPlayerData);
        Debug.Log("Game Saved");
    }

    public void LoadFromJson()
    {
        string filePath = Application.persistentDataPath + "/PlayerData.json";
        string stringPlayerData = System.IO.File.ReadAllText(filePath);

        playerData = JsonUtility.FromJson<PlayerData>(stringPlayerData);
    }
}

[System.Serializable]
public class PlayerData
{
    public bool interior;
}