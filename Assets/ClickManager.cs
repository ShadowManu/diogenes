using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{
    [SerializeField]
    private LayerMask entityLayer;

    // Update is called once per frame
    void Update()
    {
        if  (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit rayHit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, 10000f, entityLayer)) 
            {
                rayHit.collider.GetComponent<Unit>().onClick();
            }

        }
        
    }
}
