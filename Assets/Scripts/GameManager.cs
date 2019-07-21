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
            Unit unit = selectedUnit.GetComponent<Unit>();
            //Checks if the entity to perform an action on is a unit
            if (entity.GetComponent<Unit>() != null)
            {
                unit.startAttacking(entity);
            }
            //Checks if the entity to perform an action on is a resource
            if (entity.GetComponentInParent<ResourceObject>() != null)
            {
                //Workers harvest resources
                if (unit.unitEntity.entityTypes.Contains(workerEntityType))
                {
                    //Harvest
                    Debug.Log("HARVEST");
                }
                //Other units move there
                else 
                {
                    unit.stopAndMoveTo(entity.transform.position);
                }
            }
        }
    }

    public void destroyEntity(GameObject entity)
    {
        Unit su = selectedUnit.GetComponent<Unit>();
        if (su.targettedEntity == entity)
        {
            su.stopAttacking();
        }

        Destroy(entity);
    }
}
