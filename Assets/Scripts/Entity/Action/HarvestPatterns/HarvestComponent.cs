using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestComponent : MonoBehaviour
{
    public int maxHarvestCapacity = 20;
    public int harvestAmount = 0;
    public Harvest InstantiateHarvestAction(GameObject character, GameObject target) 
    {
        return new Harvest(character, target);
    }
}
