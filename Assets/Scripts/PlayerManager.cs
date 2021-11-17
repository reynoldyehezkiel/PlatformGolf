using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public static bool isGameFinish;
    public GameObject gameFinishScreen;

    private void Awake()
    {
        isGameOver = false;
        isGameFinish = false;
    }

    void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
        }

        if(isGameFinish)
        {
            gameFinishScreen.SetActive(true);
        }
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
