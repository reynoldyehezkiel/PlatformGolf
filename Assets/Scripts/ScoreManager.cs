using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text coinScore;
    public Text shotScore;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        coinScore.text = GolfController.totalCoins.ToString();
        shotScore.text = GolfController.totalShots.ToString();
    }
}
