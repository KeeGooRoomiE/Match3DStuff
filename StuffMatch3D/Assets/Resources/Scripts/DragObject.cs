using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************
 * DragonGameStudios 2021
 * Created by Spartan121
 * contacts:
 * telegram @spartan121
 * email spartan.dgs.121@icloud.com
 * 
*****************/

public class DragObject : MonoBehaviour

{
    private Vector3 mOffset;
    private float mZCoord;
    //public SelectObject self;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset + new Vector3(0,2f,0);
    }
}