using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObject : MonoBehaviour
{
    [SerializeField]
    Resource resourceType;
    [SerializeField]
    ResourceEntity resourceEntity;

    public int Harvested() 
    {
        int harvestValue = resourceEntity.Harvested();
        if (!resourceEntity.isAlive())
        {
            Destroy(gameObject);
        }
        return(harvestValue);
    }
}
