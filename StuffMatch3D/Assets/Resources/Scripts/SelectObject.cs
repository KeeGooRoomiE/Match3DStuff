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

public class SelectObject : MonoBehaviour
{
    [SerializeField] public GameController game;
    [SerializeField] private Renderer render;
    [SerializeField] private SelectObject self;
    [SerializeField] public int objectId;
    [SerializeField] public bool isSelected;

    // Start is called before the first frame update
    void Start()
    {
        isSelected = false;
        render = GetComponent<Renderer>();
        self = GetComponent<SelectObject>();
        var gameGO = GameObject.FindGameObjectWithTag("GameController");
        game = gameGO.GetComponent<GameController>();
    }

    // Deletes object 
    void Delete()
    {
        Destroy(this.gameObject);
        Debug.Log("object deleted");
    }

    // Adds score to level
    void AddScore()
    {
        game.levelScore++;
        Debug.Log("controller score added");
        Debug.Log("game score: " + game.levelScore);
    }

    // Changes color of object
    void SetMaterialColor(Color col)
    {
        render.material.SetColor("_Color", col);
    }

    // Clear controller object value 
    void ClearControllerObject()
    {
        game.selectedObj = null;
        Debug.Log("controller selected object cleared");
    }

    // Sets controller object value
    void SetControllerObject(SelectObject obj)
    {
        Debug.Log("sended object to controller");
        game.selectedObj = obj;
    }

    // Handle press on object
    void OnMouseDown()
    {
        // Sawp selection value
        isSelected = !isSelected;

        //checkout if object selected
        if (isSelected == true)
        {
            Debug.Log("selected Object ID: " + objectId);
            SetMaterialColor(Color.blue);

            if (game.selectedObj == null)
            {
                SetControllerObject(self);
            }
            else {
                Debug.Log("controller already has object");
                Debug.Log("compare controller id and selected id");

                if (game.selectedObj.objectId == objectId)
                {
                    Debug.Log("compare MATCH");
                    game.selectedObj.isSelected = false;
                    isSelected = false;
                    game.selectedObj.SetMaterialColor(Color.white);
                    SetMaterialColor(Color.white);
                    game.selectedObj.Delete();
                    ClearControllerObject();
                    AddScore();
                    Delete();
                } else
                {
                    Debug.Log("compare MISMATCH");
                    game.selectedObj.SetMaterialColor(Color.white);
                    SetMaterialColor(Color.white);
                    game.selectedObj.isSelected = false;
                    isSelected = false;
                    ClearControllerObject();
                }
            }
        }
        else
        {
            Debug.Log("Object ID: " + objectId + " unselected");
            SetMaterialColor(Color.white);
            ClearControllerObject();
        }
    }

}
