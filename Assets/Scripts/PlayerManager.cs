using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public static bool isGameFinish;
    public GameObject gameFinishScreen;

    public GameObject pauseMenuScreen;

    public GameObject Panel;

    public Button pauseButton;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Awake()
    {
        isGameOver = false;
        isGameFinish = false;
    }

    void Update()
    {
        if (isGameOver)
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

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButton.interactable = false;
        GolfController.canShoot = false;
        pauseMenuScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseButton.interactable = true;
        GolfController.canShoot = true;
        pauseMenuScreen.SetActive(false);
    }

    public void OpenPopUpMessagePanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
            StartCoroutine(HideUI(Panel, 1.5f));
        }
    }

    IEnumerator HideUI(GameObject guiParentCanvas, float secondsToWait, bool show = false)
    {
        yield return new WaitForSeconds(secondsToWait);
        guiParentCanvas.SetActive(show);
    }
}
