using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class canvasButtons : MonoBehaviour
{
    public void restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void returntomenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
