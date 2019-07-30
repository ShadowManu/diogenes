using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Attack : Action
{
    [SerializeField]
    protected UnitEntity attackerEntity;
    protected float attackSpeed = 0;
    public abstract void PerformAttack(Unit target);

    public Movement movementHandler;

    public Attack() {}

    public Attack(GameObject character, GameObject targetEntity)
    {
        this.character = character;
        this.target = targetEntity;
        Unit unitComponent = character.GetComponent<Unit>();
        attackerEntity = unitComponent.unitEntity;
        movementHandler = unitComponent.movementHandler;
        attackSpeed = attackerEntity.attackTime;
    }

    /* The main attack cycle
     * If a targetted unit is within range, attack it.
     * Otherwise, chase the unit to get withing range.
     */
    public override void ResolveAction() 
    {
        reduceAttackTimeTick();

        float rangeToTarget = Vector3.Distance(character.transform.position, target.transform.position);
        if (rangeToTarget < attackerEntity.attackRange)
        {
            movementHandler.disableMoving();
            if (attackSpeed == 0f)
            {
                PerformAttack(target.GetComponent<Unit>());
            }
        }
        else 
        {
            movementHandler.enableMoving();
            movementHandler.moveTo(target.transform.position);
        }
    }

    public override bool IsFinished()
    {
        return(!target.GetComponent<Unit>().unitEntity.isAlive());
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

}
