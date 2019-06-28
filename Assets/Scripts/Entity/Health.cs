using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Defines a current health/maxHealth structure.
 */
[CreateAssetMenu(menuName = "Units/Health")]
public class Health : ScriptableObject
{
    public IntVariable maxHealth;
    public IntVariable currHealth {get; private set;}

    private void OnEnable() 
    {
        //Initializes current health to its max health
        currHealth = ScriptableObject.CreateInstance<IntVariable>();
        currHealth.setValue(maxHealth);
    }

    public int getCurrentHealth() 
    {
        return currHealth.value;
    }

    /** 
        Modifies the health of a unit, from a damaging or a healing effect
    */
    public void updateHealth(int val) 
    {
        currHealth.updateValue(val);
        int cH = currHealth.value;
        if (cH < 0) 
        {
            currHealth.setValue(0);
        }
        else if (cH > maxHealth.value) 
        {
            currHealth.setValue(maxHealth);
        }
    }    

    /** 
        To show a health value with prints and Debug.Logs
    */
    public override string ToString() 
    {
        return currHealth.ToString() + "/" + maxHealth.ToString();
    }
}
