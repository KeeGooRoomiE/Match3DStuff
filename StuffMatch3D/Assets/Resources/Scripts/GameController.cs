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
    [SerializeField] public GameObject timeIsOutScreen;
    [SerializeField] public GameObject winScreen;
    [SerializeField] public GameObject failScreen;
    [SerializeField] public GameObject bkg;
    [SerializeField] public SelectObject selectedObj;
    [SerializeField] public Transform generatorArea;
    [SerializeField] public GameObject objectsParent;
    [SerializeField] public GameObject[] objects;
    [SerializeField] public int levelScore;
    [SerializeField] public int pairGenNumber;
    [SerializeField] private bool isNeedToCreateObjects;
    [SerializeField] public bool isTutorial;
    [SerializeField] public Text timeText;
    [SerializeField] public int levelTime;


    // Start is called before the first frame update
    void Start()
    {
        if (isNeedToCreateObjects == true)
        {
            GeneratePairs(pairGenNumber);
        }
        StartCoroutine(Countdown());
    }

    // Generate number of paired objects to scene
    void GeneratePairs(int numberOfPairs)
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

    void Update()
    {
        //update time
        var min = Mathf.Floor(levelTime / 60);
        var sec = levelTime - min * 60;

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

        if (pairGenNumber - 1 == levelScore)
        {
            winScreen.SetActive(true);
            bkg.SetActive(true);
        }
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);

        if (levelTime > 0)
        {

            levelTime -= 1;
            StartCoroutine(Countdown());

        }
        else
        {
            //stop time and make time is out screen active
            timeIsOutScreen.SetActive(true);
            bkg.SetActive(true);
        }
        
    }
}
