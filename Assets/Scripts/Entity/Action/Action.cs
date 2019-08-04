using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Action handler class */
public class Action
{
    protected GameObject character;
    protected GameObject target;

    public virtual void ResolveAction() {}
    public virtual bool IsFinished() {return true;}
}
