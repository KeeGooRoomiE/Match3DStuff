using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterSwitcher : MonoBehaviour
{
    public GameController controller;
    public GameObject booster1;
    public GameObject booster2;

    // Start is called before the first frame update
    void Start()
    {
        var gameGO = GameObject.FindGameObjectWithTag("GameController");
        controller = gameGO.GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        booster1.SetActive(controller.isBooster1On);
        booster2.SetActive(controller.isBooster2On);
    }
}
