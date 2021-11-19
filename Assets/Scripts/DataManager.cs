using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public Text coinScore;
    public Text shotScore;
    public InputField playerName;

    private void Start()
    {
        Load();
    }

    private void Update()
    {
        coinScore.text = GolfController.tempCoins.ToString();
        shotScore.text = GolfController.tempShots.ToString();
    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int coins;
        public int shots;
    }

    public void Save()
    {
        SaveData data = new SaveData();
        data.name = playerName.text;
        data.coins = int.Parse(coinScore.text);
        data.shots = int.Parse(shotScore.text);

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.txt", json);

        //string json = JsonUtility.ToJson(data);
        //WriteToFile(file, json);
    }

    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.txt";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName.text = data.name;
            coinScore.text = data.coins.ToString();
            shotScore.text = data.shots.ToString();
        }
        else
            Debug.LogWarning("File not found!");

        //data = new PlayerData();
        //string json = ReadFromFile(file);
        //JsonUtility.FromJsonOverwrite(json, data);
    }

    private void WriteToFile(string fileName, string json)
    {
        string path = GetFilePath(fileName);
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(json);
        }
    }

    private string ReadFromFile(string fileName)
    {
        string path = GetFilePath(fileName);
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                return json;
            }
        }
        else
            Debug.LogWarning("File not found!");

        return "";
    }

    private string GetFilePath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    public void ChangeName(string text)
    {
        playerName.text = text;
    }
}
