using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesPanel : MonoBehaviour
{
    public GameObject Panel;
    private bool panelOpened = false;

    public void OpenClosePanel()
    {
        if(Panel != null && panelOpened == false)
        {
            Panel.SetActive(true);
            panelOpened = true;
        }
        else if (Panel != null && panelOpened == true)
        {
            Panel.SetActive(false);
            panelOpened = false;
        }
    }
}
