using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute()]
public class FloorData : ScriptableObject
{
    public float drag;
    public float angularDrag;

    public virtual void OnEnter(PhysicObject obj)
    {
        obj.Body.drag = drag;
        obj.Body.angularDrag = angularDrag;
    }
    public virtual void OnExit(PhysicObject obj)
    {
        obj.Body.drag = obj.defaultDrag;
        obj.Body.angularDrag = obj.defaultAngularDrag;
    }
    public virtual void OnFixedUpdate(PhysicObject insideBody)
    {
       
    }


}
