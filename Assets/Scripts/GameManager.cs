using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/*
    Singleton object that handles a player state
 */
public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Singleton pattern

    public GameObject selectedUnit;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else 
        { 
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /* Takes a point and moves every selected unit to that point */
    public void moveUnits(Vector3 point) 
    {
        if (selectedUnit != null) 
        {
            selectedUnit.GetComponent<Unit>().stopAndMoveTo(point);
        }
    }

    /* Every selected unit performs an action on the entity that was clicked */
    public void performActionUnits(GameObject entity) 
    {
        if (selectedUnit != null) 
        {
            //Checks if the entity to perform an action on is a unit
            if (entity.GetComponent<Unit>() != null)
            {
                Unit unit = selectedUnit.GetComponent<Unit>();
                unit.startAttacking(entity);
            }
        }
    }
}
