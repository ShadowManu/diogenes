using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
	Basic entity class from which all other entities derive.
 */
public class EntityData : ScriptableObject
{
	public string entityName;
    public List<EntityTypeSO> entityTypes = new List<EntityTypeSO>();
	public Health health;
}
