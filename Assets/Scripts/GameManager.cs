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

    [SerializeField]
    private EntityTypeSO workerEntityType;  //Dirty fix for comparing if a unit is a worker

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
            selectedUnit.GetComponent<Unit>().startPerformingAction(entity);
        }
    }

    public void destroyEntity(GameObject entity)
    {
        Unit su = selectedUnit.GetComponent<Unit>();
        if (su.targettedEntity == entity)
        {
            su.stopPerformingAction();
        }

        Destroy(entity);
    }
}
