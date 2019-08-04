using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Entites that work as harvestable resources, such as trees, mines, etc */
[CreateAssetMenu(menuName="Entities/ResourceEntity")]
public class ResourceEntity : EntityData
{
    public int Harvested() 
    {
        int harvestValue = Mathf.Min(health.currHealth, 5);
        takeDamage(5);
        return harvestValue;
    }
}
