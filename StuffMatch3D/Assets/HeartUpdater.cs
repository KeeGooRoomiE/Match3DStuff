using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartUpdater : MonoBehaviour
{
    public HeartManager manager;
    public Text heartText;
    public HeartIcon icon1;
    public HeartIcon icon2;
    public HeartIcon icon3;

    void Update()
    {
        SetUpdates();
    }

    public void SetUpdates()
    {
        if (manager.gameObject.activeSelf)
        {
            if (heartText != null)
            {
                manager.lifeLeftText = heartText;
            }
            manager.heart1 = icon1;
            manager.heart2 = icon2;
            manager.heart3 = icon3;
        }
    }
}
