using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask entityLayer, groundLayer;


    // Update is called once per frame
    void Update()
    {
        //Handles Unit Selection
        if  (Input.GetMouseButtonDown(0)) //Left click
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 10000f, entityLayer)) 
            {
                rayHit.collider.GetComponent<Unit>().onClick();
            }

        }

        //Handles Unit movement
        if (Input.GetMouseButtonDown(1)) //Right Click
        {
            RaycastHit rayHit;
            //Target another entity to make an action
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 10000f, entityLayer)) 
            {
                //Targetted a unit. Action will be performed
                if (rayHit.collider.GetComponent<Unit>() != null )
                {
                    GameManager.instance.performActionUnits(rayHit.transform.gameObject);
                }
            }
            else if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 10000f, groundLayer)) 
            {
                if (GameManager.instance != null) 
                {
                    GameManager.instance.moveUnits(rayHit.point);
                }
            }

        }
        
    }
}
