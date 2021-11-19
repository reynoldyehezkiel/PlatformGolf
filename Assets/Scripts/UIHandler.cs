using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class UIHandler : MonoBehaviour
{
    public void Exit()
    {
        DataManager.Instance.Save();
        #if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
        #else
        Application.Quit(); // original code to quit Unity player
        #endif
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void StageOne()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToSelectStage()
    {
        SceneManager.LoadScene(1);
    }

    // public void SaveClicked()
    // {
    //     DataManager.Instance.Save();
    // }

    // public void ChangeName(string text)
    // {
    //     DataManager.Instance.playerName.text = text;
    // }

}
