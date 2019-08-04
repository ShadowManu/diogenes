using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask entityLayer, groundLayer, resourceLayer;


    // Update is called once per frame
    void Update()
    {
        //Handles Unit Selection
        if  (Input.GetMouseButtonDown(0)) //Left click
        {
            RaycastHit rayHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out rayHit, 10000f, entityLayer)) 
            {
                rayHit.collider.GetComponent<Unit>().onClick();
            }

        }

        //Handles Unit movement
        if (Input.GetMouseButtonDown(1)) //Right Click
        {
            RaycastHit rayHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Target another entity to make an action
            if (Physics.Raycast(ray, out rayHit, 10000f, entityLayer)) 
            {
                GameManager.instance.performActionUnits(rayHit.transform.gameObject);
            }
            //Target the ground to move
            else if (Physics.Raycast(ray, out rayHit, 10000f, groundLayer)) 
            {
                if (GameManager.instance != null) 
                {
                    GameManager.instance.moveUnits(rayHit.point);
                }
            }

        }
        
    }
}
