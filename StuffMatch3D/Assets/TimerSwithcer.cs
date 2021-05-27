using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerSwithcer : MonoBehaviour
{
    public GameController controller;
    public GameObject timerText;

    // Start is called before the first frame update
    void Start()
    {
        var gameGO = GameObject.FindGameObjectWithTag("GameController");
        controller = gameGO.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        timerText.SetActive(controller.isTimerOn);
    }
}
