using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Attack : MonoBehaviour
{
    [SerializeField]
    protected UnitEntity attackerEntity;
    protected float attackSpeed = 0;
    public abstract void attack(Unit target);

    public Movement movementHandler;

    private void Start() 
    {
        attackSpeed = attackerEntity.attackTime;
        movementHandler = gameObject.GetComponent<Movement>();
    }

    private void FixedUpdate() 
    {
        reduceAttackTimeTick();
    }

    /* Reduces attack time by a fixedTime tick */
    private void reduceAttackTimeTick() 
    {
        float dt = Time.fixedDeltaTime;
        attackSpeed = attackSpeed - dt < 0f ? 0f : attackSpeed - dt;
    }

    /* The main attack cycle
     * If a targetted unit is within range, attack it.
     * Otherwise, chase the unit to get withing range.
     */
    public void resolveAttackAction(GameObject targettedEntity) 
    {
        float rangeToTarget = Vector3.Distance(gameObject.transform.position, targettedEntity.transform.position);
        if (rangeToTarget < attackerEntity.attackRange)
        {
            movementHandler.disableMoving();
            if (attackSpeed == 0f)
            {
                attack(targettedEntity.GetComponent<Unit>());
            }
        }
        else 
        {
            movementHandler.enableMoving();
            movementHandler.moveTo(targettedEntity.transform.position);
        }
    }
}
