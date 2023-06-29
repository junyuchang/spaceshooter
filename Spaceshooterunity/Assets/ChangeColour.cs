using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour
{
    public Button upgradesButton;
    // Changes colour to yellow after five seconds (TEMPORARY)
    public int changeinseconds = 3;

    void Start()
    {
        StartCoroutine(ChangeColourSeconds(changeinseconds));
    }

    IEnumerator ChangeColourSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        ColorBlock colors = upgradesButton.colors;
        colors.normalColor = Color.yellow;
        upgradesButton.colors = colors;
    }

    public void ButtonPressed()
    {

    }
}
