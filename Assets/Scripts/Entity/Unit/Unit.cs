using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Class that defines a GameObject attached to a unit structure.
 */
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

    /* Function that is called when the Unit is clicked */
    public void onClick() 
    {
        Debug.Log("Clicked the " + unitEntity.entityName + " Entity!");
        Text text = GameObject.Find("SelectedUnitChecker").GetComponent<Text>();
        text.text = "Selected Unit: " + unitEntity.entityName;
        if (GameManager.instance != null) 
        {
            GameManager.instance.selectedUnit = gameObject;
        }
    }

}
