using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Action extension class that defiens harvest behaviours */
public class Harvest : Action
{
    Movement movementHandler;
    UnitEntity unit;
    
    public Harvest(GameObject character, GameObject targetResource) {
        this.character = character;
        this.target = targetResource;
        Unit unitComponent = character.GetComponent<Unit>();
        movementHandler = unitComponent.movementHandler;
        unit = unitComponent.unitEntity;
    }

    public override void ResolveAction() 
    {
        float rangeToTarget = Vector3.Distance(character.transform.position, target.transform.position);
        if (rangeToTarget < unit.attackRange)
        {
            movementHandler.disableMoving();
            //Performs a harvest
            Debug.Log("HARVEST");
        }
        else 
        {
            movementHandler.enableMoving();
            movementHandler.moveTo(target.transform.position);
        }
    }
    public override bool IsFinished() {
        return target == null;
    }
}
