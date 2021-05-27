using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTextBinder : MonoBehaviour
{

    [SerializeField] private GameObject controller;
    [SerializeField] private Text textComp;
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("Master");
        textComp = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        int rep = controller.GetComponent<LevelManager>().levelNumber;
        Debug.Log("String to change: "+rep.ToString());
        string output = textComp.text.Replace("{NUM}", rep.ToString());
        textComp.text = output;
        Debug.Log(textComp.text);
    }
}
