using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    public double countdownTime;
    public Text countdownDisplay;
    public Text itemsRem;
    public int totItems;
    public int nitemToSpawn;
    internal int itemsPicked = 0;
    public int mistake = 0;
    public List<GameObject> itemToSpawn;
    public List<GameObject> errAlert;
    public GameObject overPanel;
    public GameObject pausePanel;
    public GameObject exitPanel;
    public Text overText;

    void Start()
    {
        StartGame();
        SpawnItem(nitemToSpawn);
        StartCoroutine(Countdown());
    }

    void Update()
    {
        int rem = totItems - itemsPicked;
        itemsRem.text = rem.ToString();
        Pause();
        GameWin();
        checkMistake();
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);
            //countdownTime--;
            countdownTime -= 1;
        }

        countdownDisplay.text = "FINE!";
        overText.text = "Il tempo è scaduto!";
        GameOver();

        yield return new WaitForSeconds(1f);
    }


    void GameOver()
    {
        overPanel.SetActive(true);
        Time.timeScale = 0;
        /*
        SimpleSampleCharacterControl a;
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleSampleCharacterControl>();
        a.setMovSpeedPub(0);*/
    }

    void GameWin()
    {
        if (itemsPicked >= totItems)
        {
            //Win condition
            countdownDisplay.text = "VINTO!";
            overText.text = "Complimenti hai vinto!";
            GameOver();
        }
    }

    void StartGame()
    {
        Time.timeScale = 1;
        overPanel.SetActive(false);
        pausePanel.SetActive(false);
        exitPanel.SetActive(false);
        for (int i = 0; i <= 2; i++)
        {
            errAlert[i].SetActive(false);
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
    public void unPause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void noExit()
    {
        if (!exitPanel.activeSelf)
        {
            pausePanel.SetActive(false);
            exitPanel.SetActive(true);
        }
        else
        {
            exitPanel.SetActive(false);
            pausePanel.SetActive(true);
        }
    }

    internal void incItemPicked()
    {
        itemsPicked++;
    }

    internal void incMistake()
    {
        mistake++;
        if (mistake <= 3 && mistake > 0)
        {
            errAlert[mistake - 1].SetActive(true);
        }
    }

    internal void checkMistake()
    {
        if (mistake >= 3)
        {
            overText.text = "Hai commesso troppi errori!";
            GameOver();
        }
    }

    void SpawnItem(int num)
    {
        List<GameObject> spawnList = new List<GameObject>();
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            spawnList.Add(fooObj);
        }

        if (spawnList.Count >= num)
        {
            for(int i=0; i<num; i++)
            {
                int rndSpawn = Random.Range(0, spawnList.Count);
                int rndItem = Random.Range(0, itemToSpawn.Count);

                Instantiate(itemToSpawn[rndItem], spawnList[rndSpawn].transform.position, Quaternion.identity);
            }

        }
    }
}
