using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarAnimation : MonoBehaviour
{

    
    public Image img;
    public Transform StarTransform;
    public Color col;
    public double alpha;
    public bool incr;
    // Start is called before the first frame update
    void Start()
    {
        StarTransform = gameObject.GetComponent<Transform>();
        img = gameObject.GetComponent<Image>();
        col = img.color;

        alpha = Random.Range(0f, 1f);
        var xx = Random.Range(-300f, 300f);
        var yy = Random.Range(-500f, 500f);
        StarTransform.position += new Vector3(xx, yy,0);
        var sc = Random.Range(0.2f, 0.8f);
        StarTransform.localScale += new Vector3(sc, sc, sc);
    }

    // Update is called once per frame
    void Update()
    {
        if (incr)
        {
            if (alpha < 1)
            {
                alpha += 0.01;
            } else
            {
                incr = false;
            }
        } else
        {
            if (alpha > 0)
            {
                alpha -= 0.01;
            } else
            {
                incr = true;
            }
        };

        col.a = (float)alpha;
        img.color = col;
    }
}
