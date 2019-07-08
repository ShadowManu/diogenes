using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : Attack
{
    public override void attack(Unit target) 
    {
        bool isTargetAlive = target.takeDamage(attackerEntity.damage);
        attackSpeed = attackerEntity.attackTime;
    }
}
