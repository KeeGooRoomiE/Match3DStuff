using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public int HeartCount;
    public int secondsBeforeNextHeart;
    //public int curTimestamp;
    public Text lifeLeftText;
    public HeartIcon heart1;
    public HeartIcon heart2;
    public HeartIcon heart3;
    public Button menuPlayButton;
    public Button failRestartButton;
    private int counter;
    private bool isCountdowning;

    // Start is called before the first frame update
    void Start()
    {
        RestartCounter();
        StartCoroutine(HeartCountdown());
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();

        //first heart checkout, basic one 
        if (heart1.gameObject != null)
        {
            if (HeartCount >=1)
            {
                heart1.active.gameObject.SetActive(true);
            } else
            {
                heart1.active.gameObject.SetActive(false);
            }
        }

        //second heart checkout
        if (heart2.gameObject != null)
        {
            if (HeartCount >= 2)
            {
                heart2.active.gameObject.SetActive(true);
            }
            else
            {
                heart2.active.gameObject.SetActive(false);
            }
        }

        //third heart checkout
        if (heart3.gameObject != null)
        {
            if (HeartCount >= 3)
            {
                heart3.active.gameObject.SetActive(true);
            }
            else
            {
                heart3.active.gameObject.SetActive(false);
            }
        }

        if (HeartCount<=0)
        {
            menuPlayButton.interactable = false;
            failRestartButton.interactable = false;
        } else
        {
            menuPlayButton.interactable = true;
            failRestartButton.interactable = true;
        }
    }

    public void UpdateText() {
        if (lifeLeftText != null)
        {
            lifeLeftText.gameObject.SetActive(true);
            if (HeartCount < 3)
            {
                //lifeLeftText.text = "next life in ";
                //count left time

                var min = Mathf.Floor(counter / 60);
                var sec = counter - min * 60;
                string tim = string.Format("{0:00}:{1:00}", min, sec);//min + " : " + sec;
                lifeLeftText.text = "next life in " + tim;
            } else
            {
                //lifeLeftText.gameObject.SetActive(false);
                lifeLeftText.text = " ";
            }
        }    
    }

    private IEnumerator HeartCountdown()
    {
        yield return new WaitForSeconds(1);

        if (counter > 0)
        {

            counter -= 1;
            StartCoroutine(HeartCountdown());
            isCountdowning = true;

        }
        else
        {
            isCountdowning = false;
            IncreaseHeartCount(1);
            if (HeartCount < 3)
            {
                RestartCounter();
            }
        }

    }

    private void RestartCounter()
    {
        counter = secondsBeforeNextHeart;
    }

    public void DecreaseHeartCount() {
        HeartCount -= 1;
        Debug.Log("heart count decreased to a value: " + HeartCount + " via Controller function");
        if (!isCountdowning)
        {
            RestartCounter();
            StartCoroutine(HeartCountdown());
        }


    }

    public void IncreaseHeartCount(int amount)
    {
        if (HeartCount + amount <= 3)
        {
            HeartCount += amount;
        } else
        {
            HeartCount = 3;
        }

        Debug.Log("heart count decreased to a value: " + HeartCount + " via Controller function");
    }

    public void SetHeartAmount(int amount)
    {
        HeartCount = amount;
        Debug.Log("heart count set to "+ HeartCount+" via Controller function");
    }
}
