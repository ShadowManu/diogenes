using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Action extension class that defiens harvest behaviours */
public class Harvest : Action
{
    Movement movementHandler;
    UnitEntity unit;
    HarvestComponent harvestComponent;
    float harvestSpeed; 
    int maxHarvestCapacity = 20;
    int harvestAmount;
    
    public Harvest(GameObject character, GameObject targetResource) {
        this.character = character;
        this.target = targetResource;
        Unit unitComponent = character.GetComponent<Unit>();
        movementHandler = unitComponent.movementHandler;
        unit = unitComponent.unitEntity;
        harvestSpeed = unit.attackTime;
        //Sets harvest component info, so that 
        //harvested resources are not lost if this action is dequeued
        harvestComponent = character.GetComponent<HarvestComponent>();
        harvestComponent.resourceType = target.GetComponent<ResourceObject>().getResourceType();
        harvestAmount = harvestComponent.harvestAmount;
    }

    /* Reduces the time for the next Harvest action then 
        performs a Harvest action if possible.*/
    public override void ResolveAction() 
    {
        reduceHarvestTimeTick();
        if (target != null)
        {
            float rangeToTarget = Vector3.Distance(character.transform.position, target.transform.position);
            if (rangeToTarget < unit.attackRange)
            {
                movementHandler.disableMoving();
                if (harvestSpeed <= 0)  //Check if able to harvest
                {
                    performHarvest();
                }
            }
            else  //Move to the harvest target
            {
                movementHandler.enableMoving();
                movementHandler.moveTo(target.transform.position);
            }
        }
    }
    
    public override bool IsFinished() {
        return target == null;
    }

    /* Attempts to perform a harvest if harvest capacity is not reached.
        Otherwise, deposits harvested resources */
    private void performHarvest()
    {
        if (harvestAmount >= maxHarvestCapacity)
        {
            //Move to the town hall and leave stuff
            Debug.Log("MAX VALUE REACHED");
        }
        else 
        {
            harvestSpeed = unit.attackTime;
            harvestAmount += target.GetComponent<ResourceObject>().Harvested();
            harvestComponent.harvestAmount = harvestAmount; //Retroactively adds it to save harvest info
            //Performs a harvest
            Debug.Log("harvest amount " + harvestAmount);
        }
    }

    /* Reduces attack time by a fixedTime tick */
    private void reduceHarvestTimeTick() 
    {
        float dt = Time.fixedDeltaTime;
        harvestSpeed = harvestSpeed - dt < 0f ? 0f : harvestSpeed - dt;
    }
}
