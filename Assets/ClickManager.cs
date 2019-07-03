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
        if  (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 10000f, entityLayer)) 
            {
                rayHit.collider.GetComponent<Unit>().onClick();
            }

        }

        //Handles Unit movement
        if (Input.GetMouseButtonDown(1)) 
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 10000f, groundLayer)) 
            {
                if (GameManager.instance != null) 
                {
                    GameManager.instance.moveUnits(rayHit.point);
                }
            }

        }
        
    }
}
