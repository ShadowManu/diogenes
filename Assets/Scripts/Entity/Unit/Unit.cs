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

    /* The main attack cycle
     * If a targetted unit is within range, attack it.
     * Otherwise, chase the unit to get withing range.
     */
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

    /* Resets attacking and following and attacked unit */
    private void disableAttackBehavior()
    {
        //Disables attack 
        targettedEntity = null;
        isAttacking = false;
        //Resets movement
        NavMeshAgent nmAgent = gameObject.GetComponent<NavMeshAgent>();
        nmAgent.isStopped = false;
        nmAgent.SetDestination(transform.position);
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

    /* Stops all action and moves the unit to a point */
    public void stopAndMoveTo(Vector3 point) 
    {
        disableAttackBehavior();
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
            disableAttackBehavior();
        }
    }

    /* Take damage from an outside source */
    public bool takeDamage(int damage) 
    {
        unitEntity.takeDamage(damage);
        Debug.Log(unitEntity.health);
        bool isAlive = unitEntity.isAlive();
        if (!isAlive) 
        {
            Destroy(gameObject);
        }
        return isAlive;
    }
}
