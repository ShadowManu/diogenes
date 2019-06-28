using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class that defines a unit attached to a game object
public class Unit : MonoBehaviour
{
    public UnitEntity unitEntity;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void takeDamage(int damage) 
    {
        unitEntity.health.updateHealth(-damage);
    }
}
