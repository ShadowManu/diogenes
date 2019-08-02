﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackComponent : MonoBehaviour
{
    public abstract Attack InstantiateAttackComponent(GameObject character, GameObject target);
}
