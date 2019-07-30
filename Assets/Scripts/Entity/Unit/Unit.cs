using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

/*
    Class that defines a GameObject attached to a unit structure.
 */
public class Unit : MonoBehaviour
{
    public UnitEntity unitEntity;
    public GameObject targettedEntity;
    public List<Action> actionList = new List<Action>();
    public Movement movementHandler;

    protected bool performingAction = false;

    private void Start() 
    {
        movementHandler = gameObject.GetComponent<Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (actionList.Count > 0) 
        {
            Action currentAction = actionList[0];
            currentAction.ResolveAction();
            if (currentAction.IsFinished()) 
            {
                actionList.RemoveAt(0);
            }
        }
    }

    /* Function that is called when the Unit is clicked */
    public void onClick() 
    {
        Debug.Log("Clicked the " + unitEntity.entityName + " Entity!");
        Text text = GameObject.Find("SelectedUnitChecker").GetComponent<Text>();
        text.text = "Selected Unit: " + unitEntity.entityName;
        if (GameManager.instance != null) 
        {
            GameManager.instance.selectedUnit = gameObject;
        }
    }

    /* Performs an action based on the given target and the unit's type */
    public void startPerformingAction(GameObject entity) 
    {
        //Attacks another unit
        if (entity.GetComponent<Unit>() != null)
        {
            AttackComponent attack = gameObject.GetComponent<AttackComponent>();
            if (attack != null)
            {
                Debug.Log("ATTACK");
                actionList.Clear();
                actionList.Add(attack.InstantiateAttackComponent(gameObject, entity));
            }
            //Add a new attack action
            // startAttacking(entity);
        }
        //Checks if the entity to perform an action on is a resource
        if (entity.GetComponentInParent<ResourceObject>() != null)
        {
            HarvestComponent harvest = gameObject.GetComponent<HarvestComponent>();
            //If harvesting is posible, do it
            if (harvest != null)
            {
                //Harvest
                actionList.Clear();
                actionList.Add(harvest.InstantiateHarvestAction(gameObject, entity));
            }
            //Other units move there
            else 
            {
                stopAndMoveTo(entity.transform.position);
            }
        }
    }

    public void stopPerformingAction()
    {
        performingAction = false;
        targettedEntity = null;
        actionList.Clear();
        movementHandler.enableMoving();
        movementHandler.moveTo(transform.position);
    }

    /* Stops all action and moves the unit to a point */
    public void stopAndMoveTo(Vector3 point) 
    {
        actionList.Clear();
        targettedEntity = null;
        movementHandler.enableMoving();
        movementHandler.moveTo(point);
    }

    /* Take damage from an outside source */
    public bool takeDamage(int damage) 
    {
        unitEntity.takeDamage(damage);
        Debug.Log(unitEntity.health);
        bool alive = isAlive();
        if (!alive) 
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.destroyEntity(gameObject);
            }
        }
        return alive;
    }

    public bool isAlive()
    {
        return unitEntity.isAlive();
    }
}
