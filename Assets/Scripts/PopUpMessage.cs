using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpMessage : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        if(Panel != null)
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
