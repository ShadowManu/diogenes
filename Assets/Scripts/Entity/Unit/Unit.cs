﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

/*
    Class that defines a GameObject attached to a unit structure.
 */
public class Unit : MonoBehaviour
{
    public UnitEntity unitEntity;
    public GameObject targettedEntity;
    public Attack attackPattern;
    public Movement movementHandler;

    protected bool isAttacking = false;

    private void Start() 
    {
        attackPattern = gameObject.GetComponent<Attack>();
        movementHandler = gameObject.GetComponent<Movement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAttacking)
        {
            if (targettedEntity != null) 
            {
                attackPattern.resolveAttackAction(targettedEntity);
            }
            else 
            {
                stopAttacking();
            }
        }
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
    

    /* Stops all action and moves the unit to a point */
    public void stopAndMoveTo(Vector3 point) 
    {
        stopAttacking();
        movementHandler.moveTo(point);
    }

    /* Sets attacking flags and chases an enemy to attack */
    public void startAttacking(GameObject entity)
    {
        targettedEntity = entity;
        isAttacking = true;
    }

    /* Resets attacking and following and attacked unit */
    public void stopAttacking()
    {
        //Disables attack 
        targettedEntity = null;
        isAttacking = false;
        //Resets movement
        movementHandler.enableMoving();
        movementHandler.moveTo(transform.position);
    }


    /* Performs an attack against the selected entity */
    public void performAttack(Unit target)
    {
        if (attackPattern != null) 
        {
            attackPattern.attack(target);
        }

        if (!target.isAlive())
        {
            stopAttacking();
        }
    }

    /* Take damage from an outside source */
    public bool takeDamage(int damage) 
    {
        unitEntity.takeDamage(damage);
        Debug.Log(unitEntity.health);
        bool alive = isAlive();
        if (!alive) 
        {
            if (GameManager.instance != null)
            {
                GameManager.instance.destroyEntity(gameObject);
            }
        }
        return alive;
    }

    public bool isAlive()
    {
        return unitEntity.isAlive();
    }
}
