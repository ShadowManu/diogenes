using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Defines a current health/maxHealth structure.
 */
[CreateAssetMenu(menuName = "Entities/Health")]
public class Health : ScriptableObject
{
    public int maxHealth;
    public int currHealth {get; private set;}

    private void OnEnable() 
    {
        //Initializes current health to its max health
        currHealth = maxHealth;
    }

    /** 
        Modifies the health of a unit, from a damaging or a healing effect
    */
    public void updateHealth(int val) 
    {
        currHealth += val;
        if (currHealth < 0) 
        {
            currHealth = 0;
        }
        else if (currHealth > maxHealth) 
        {
            currHealth = maxHealth;
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
