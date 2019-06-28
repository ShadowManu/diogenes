using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableEntity : EntityData
{
    public List<ResourceValue> resourceCosts = new List<ResourceValue>();
    public float lineOfSight;
    public int damage;
    public int armor;
}
