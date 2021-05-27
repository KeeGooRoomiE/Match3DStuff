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
    [SerializeField] public SelectObject selectedObj;
    [SerializeField] public Transform generatorArea;
    [SerializeField] public GameObject objectsParent;
    [SerializeField] public GameObject[] objects;
    [SerializeField] public int numberOfActive;
    [SerializeField] public GameObject[] activeObjects;
    [SerializeField] public int levelScore;
    [SerializeField] public int pairGenNumber;
    [SerializeField] private bool isNeedToCreateObjects;
    [SerializeField] public bool isTutorial;
    [SerializeField] public Text timeText;
    [SerializeField] public int levelTime;
    [SerializeField] public int currentTime;


    // Start is called before the first frame update
    void Start()
    {
        /*if (isNeedToCreateObjects == true)
        {
            GeneratePairs(pairGenNumber);
        }*/
        //StartCoroutine(Countdown());
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
        numberOfActive = 0;
        GeneratePairs(pairGenNumber);
        SetTime(levelTime);
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

        /*if (levelTime > 0)
        {

            levelTime -= 1;
        }
        else
        {
            //stop time and make time is out screen active
        }*/
        //StartCoroutine(Countdown(1));
        timeText.text = string.Format("{0:00}:{1:00}", min, sec);//min + " : " + sec;

        if (pairGenNumber == levelScore)
        {
            manager.ShowWin();
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
