using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitObject : MonoBehaviour
{
    public GameController controller;
    // Start is called before the first frame update
    void Start()
    {
        var gameGO = GameObject.FindGameObjectWithTag("GameController");
        controller = gameGO.GetComponent<GameController>();

        if (controller != null)
        {
            controller.activeObjects[controller.numberOfActive] = gameObject;
            controller.numberOfActive++;
            Debug.Log("added object to active objects array");
        }
    }
}
