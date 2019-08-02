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
        harvestComponent = character.GetComponent<HarvestComponent>();
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

    private void performHarvest()
    {
        harvestSpeed = unit.attackTime;
        harvestAmount += target.GetComponent<ResourceObject>().Harvested();
        harvestComponent.harvestAmount = harvestAmount;
        if (harvestAmount >= maxHarvestCapacity)
        {
            Debug.Log("HARVEST CAPACITY REACHED");
        }
        //Performs a harvest
        Debug.Log("harvest amount " + harvestAmount);
    }

    /* Reduces attack time by a fixedTime tick */
    private void reduceHarvestTimeTick() 
    {
        float dt = Time.fixedDeltaTime;
        harvestSpeed = harvestSpeed - dt < 0f ? 0f : harvestSpeed - dt;
    }
}
