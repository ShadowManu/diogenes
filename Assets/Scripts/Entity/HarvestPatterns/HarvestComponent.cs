using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarvestComponent : MonoBehaviour
{
    public Harvest InstantiateHarvestAction(GameObject character, GameObject target) 
    {
        return new Harvest(character, target);
    }
}
