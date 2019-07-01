using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Any entity that can be created by spending resources, 
    such as buildings or units.
 */
public class BuildableEntity : EntityData
{
    public List<ResourceValue> resourceCosts = new List<ResourceValue>();
    public float lineOfSight;
    public int damage;
    public int armor;
}
