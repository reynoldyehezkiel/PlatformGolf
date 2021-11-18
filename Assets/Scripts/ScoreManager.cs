using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text coinScore;
    public Text shotScore;
    public InputField playerName;

    public DataManager dataManager;

    private void Start()
    {
        dataManager.Load();
        playerName.text = dataManager.data.playerName;
        coinScore.text = dataManager.data.coins.ToString();
        shotScore.text = dataManager.data.shots.ToString();
    }

    private void Update()
    {
        coinScore.text = GolfController.tempCoins.ToString();
        shotScore.text = GolfController.tempShots.ToString();
    }

    public void ChangeName(string text)
    {
        dataManager.data.playerName = text;
    }

    public void ClickSave()
    {
        dataManager.Save();
    }
}
