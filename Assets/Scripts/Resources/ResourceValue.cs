using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Resources/ResourceValue")]
public class ResourceValue : ScriptableObject
{
    public Resource resource;
    public int value;
}