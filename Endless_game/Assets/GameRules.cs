using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameRules : MonoBehaviour
{
    public double countdownTime;
    public Text countdownDisplay;
    public Text itemsRem;
    public int totItems;
    public int itemsPicked = 0;
    public List<GameObject> itemToSpawn;

    void Start()
    {
        SpawnItem(totItems);
        StartCoroutine(Countdown());
    }

    void Update()
    {
        int rem = totItems - itemsPicked;
        itemsRem.text = rem.ToString();
        GameWin();
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(0.01f);
            //countdownTime--;
            countdownTime -= 0.01;
        }

        countdownDisplay.text = "FINE!";
        GameOver();

        yield return new WaitForSeconds(1f);
    }


    void GameOver()
    {
        //Time.timeScale = 0;
        SimpleSampleCharacterControl a;
        a = GameObject.FindGameObjectWithTag("Player").GetComponent<SimpleSampleCharacterControl>();
        a.setMovSpeedPub(0);
    }

    void GameWin()
    {
        if (itemsPicked >= totItems)
        {
            //Win condition
            countdownDisplay.text = "VINTO!";
            Time.timeScale = 0;
        }
    }

    void StartGame()
    {
        Time.timeScale = 1;
    }

    internal void incItemPicked()
    {
        itemsPicked++;
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
