using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public int GenCount;
    public GameObject star;
    // Start is called before the first frame update
    void Start()
    {
        //var i=0;
        for (var i = 0; i < GenCount; i++)
        {
            Instantiate(star, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
