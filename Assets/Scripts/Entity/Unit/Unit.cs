using System.Collections;
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
    private float attackSpeed = 0;
    public bool isAttacking = false;
    

    // Start is called before the first frame update
    void Start()
    {
        attackSpeed = unitEntity.attackTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        resolveAttackAction();
    }


    private void resolveAttackAction() 
    {
        reduceAttackTimeTick();
        
        if (isAttacking) 
        {
            float rangeToTarget = Vector3.Distance(gameObject.transform.position, targettedEntity.transform.position);
            if (rangeToTarget < unitEntity.attackRange)
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = true;
                if (attackSpeed == 0f) 
                {
                    performAttack(targettedEntity.GetComponent<Unit>());
                }
            }
            else 
            {
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                moveTo(targettedEntity.transform.position);
            }
        }
    }

    /* Reduces attack time by a fixedTime tick */
    private void reduceAttackTimeTick() 
    {
        float dt = Time.fixedDeltaTime;
        attackSpeed = attackSpeed - dt < 0f ? 0f : attackSpeed - dt;
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
    
    /* Moves the unit to a point */
    public void moveTo(Vector3 point) 
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(point);
    }

    /* Sets attacking flags and chases an enemy to attack */
    public void startAttacking(GameObject entity)
    {
        targettedEntity = entity;
        isAttacking = true;
    }

    /* Performs an attack against the selected entity */
    public void performAttack(Unit target)
    {
        bool isTargetAlive = target.takeDamage(unitEntity.damage);
        attackSpeed = unitEntity.attackTime;

        if (!isTargetAlive)
        {
            //Disables attack 
            targettedEntity = null;
            isAttacking = false;
            //Resets movement
            NavMeshAgent nmAgent = gameObject.GetComponent<NavMeshAgent>();
            nmAgent.SetDestination(transform.position);
            nmAgent.isStopped = false;
        }
    }

    public bool takeDamage(int damage) 
    {
        bool isAlive = true;
        unitEntity.health.updateHealth(-damage);
        Debug.Log(unitEntity.health);
        if (unitEntity.health.currHealth == 0f) 
        {
            Destroy(gameObject);
            isAlive = false;
        }
        return isAlive;
    }
}
