using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackComponent : AttackComponent
{
    public override Attack InstantiateAttackComponent(GameObject character, GameObject target)
    {
        return new MeleeAttack(character, target);
    }
}
