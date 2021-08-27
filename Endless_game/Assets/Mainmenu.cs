using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject mainPanel;
    public GameObject creditsPanel;
    public GameObject exitPanel;

    private void Start()
    {
        tutorialPanel.SetActive(false);
        creditsPanel.SetActive(false);
        exitPanel.SetActive(false);
        GetComponent<AudioSource>().Play();
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void tutorial()
    {

        if (tutorialPanel.activeSelf)
        {
            tutorialPanel.SetActive(false);
            back();
        }
        else
        {
            //mainPanel.SetActive(false);
            tutorialPanel.SetActive(true);
        }
    }

    public void credits()
    {

        if (creditsPanel.activeSelf)
        {
            creditsPanel.SetActive(false);
            back();
        }
        else
        {
            //mainPanel.SetActive(false);
            creditsPanel.SetActive(true);
        }
    }

    public void exitP()
    {

        if (exitPanel.activeSelf)
        {
            exitPanel.SetActive(false);
            back();
        }
        else
        {
            //mainPanel.SetActive(false);
            exitPanel.SetActive(true);
        }
    }

    public void back()
    {
        mainPanel.SetActive(true);
    }
}
