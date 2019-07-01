using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Scriptable Object that holds an integer value.
 */
[CreateAssetMenu(menuName="Utilities/IntVariable")]
public class IntVariable : ScriptableObject
{
    public int value;

    public void setValue(IntVariable var) 
    {
        value = var.value;
    }

    public void setValue(int val) 
    {
        value = val;
    }

    public void updateValue(IntVariable var)
    {
        value += var.value;
    }

    public void updateValue(int val)
    {
        value += val;
    }

    public override string ToString() 
    {
        return value.ToString();
    }
}