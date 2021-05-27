using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*****************
 * DragonGameStudios 2021
 * Created by Spartan121
 * contacts:
 * telegram @spartan121
 * email spartan.dgs.121@icloud.com
 * 
*****************/

public class GameController : MonoBehaviour
{
    [SerializeField] public SceneManager manager;
    [SerializeField] public LevelManager lman;
    [SerializeField] public Transform generatorArea;
    [SerializeField] public GameObject objectsParent;
    [SerializeField] public SelectObject selectedObj;
    [SerializeField] public Text timeText;
    [SerializeField] public GameObject[] objects;
    [SerializeField] public GameObject[] activeObjects;
    [SerializeField] public int numberOfActive;
    [SerializeField] public int levelScore;
    [SerializeField] public int pairGenNumber;
    
    [SerializeField] public int levelTime;
    [SerializeField] public int currentTime;
    [SerializeField] public bool noNeedToGen = false;
    [SerializeField] public bool isTutorial;
    [SerializeField] public bool isGameWin;
    [SerializeField] public bool isTimerOn = true;
    [SerializeField] public bool isBooster1On = true;
    [SerializeField] public bool isBooster2On = true;


    // Start is called before the first frame update
    void Start()
    {
        isGameWin = false;
    }

    // Generate number of paired objects to scene
    public void GeneratePairs(int numberOfPairs)
    {
        if (generatorArea != null)
        {
            int i;
            

            for (i = 0; i < numberOfPairs; i++)
            {
                //var p = 1;
                int n;
                var index = (int)Random.Range(0, objects.Length);
                for (n = 0; n < 2; n++)
                {
                    var posHandicap = new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(-2f, 2f));
                    
                    Instantiate(objects[index], generatorArea.position + posHandicap, Quaternion.Euler(Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f), Random.Range(-180.0f, 180.0f)), objectsParent.transform);
                    
                }
            }
        }
    }

    public void StartLevel()
    {
        lman.SetLevel(lman.levelNumber);
        isGameWin = false;
        levelScore = 0;
        numberOfActive = 0;
        StopCoroutine(Countdown());

        if (!noNeedToGen)
        {
            GeneratePairs(pairGenNumber);
        }
        
        //make timer infinite if timer is off
        if (!isTimerOn)
        {
            SetTime(99999);
        } else
        {
            SetTime(levelTime);
        }

        if (!isTutorial)
        {
            var tut = GameObject.FindGameObjectsWithTag("Tutorial");
            foreach (GameObject tutorial in tut)
            {
                tutorial.SetActive(false);
            }
        } else
        {
            switch (lman.levelNumber)
            {
                default: isTutorial = false; break;
                case 1: var t1 = GameObject.FindGameObjectWithTag("Tutorial");
                    t1.SetActive(true);
                    break;
            }
        }

        StartCoroutine(Countdown());
    }

    public void DeletePairs()
    {
        int i;// = activeObjects.Length;
        for (i=0; i<activeObjects.Length; i++)
        {
            if (activeObjects[i] != null)
            {
                Destroy(activeObjects[i]);
                Debug.Log("object deleted via DeletePairs");
            }
        }
    }

    public void SetTime(int time)
    {
        currentTime = time;
    }

    public void AddTime(int time)
    {
        currentTime += time;
        StartCoroutine(Countdown());
    }

    void Update()
    {
        //update time
        var min = Mathf.Floor(currentTime / 60);
        var sec = currentTime - min * 60;
        timeText.text = string.Format("{0:00}:{1:00}", min, sec);//min + " : " + sec;

        //detrigger game win screen opening
        if (!isGameWin)
        { 
            if (pairGenNumber == levelScore)
            {
                manager.ShowWin();
                isGameWin = true;
            }
        }


    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);

        if (currentTime > 0)
        {

            currentTime -= 1;
            StartCoroutine(Countdown());

        }
        else
        {
            //stop time and make time is out screen active
            manager.ShowNoTime();
        }
        
    }
}
