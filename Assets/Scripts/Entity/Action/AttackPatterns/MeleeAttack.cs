using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    public MeleeAttack(GameObject character, GameObject targetEntity) 
                : base(character, targetEntity)
    {
        
    }

    public override void PerformAttack(Unit target) 
    {
        bool isTargetAlive = target.takeDamage(attackerEntity.damage);
        attackSpeed = attackerEntity.attackTime;
    }
}
