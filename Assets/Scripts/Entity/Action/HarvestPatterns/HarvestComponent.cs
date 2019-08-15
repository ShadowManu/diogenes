using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestComponent : MonoBehaviour
{
    public int maxHarvestCapacity = 20;
    public int harvestAmount = 0;
    public Resource resourceType;

    /* Start a new harvest action to be added to an action queue */
    public Harvest InstantiateHarvestAction(GameObject character, GameObject target) 
    {
        return new Harvest(character, target);
    }
}
