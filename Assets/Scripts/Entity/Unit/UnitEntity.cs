using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Player created entities that can move, such as workers
    and infantry.
 */
[CreateAssetMenu(menuName="Units/UnitEntity")]
public class UnitEntity : BuildableEntity
{
    public int moveSpeed;
    public int upkeep;
    public float attackTime;
    public float attackRange;
}