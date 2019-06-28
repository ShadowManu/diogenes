using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    A Resource/value pair. Used for defining unit costs
    or merchant costs.
 */
[CreateAssetMenu(menuName="Resources/ResourceValue")]
public class ResourceValue : ScriptableObject
{
    public Resource resource;
    public int value;
}