using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute()]
public class EngineData : ScriptableObject {
    public int minFixedUpdateBetweenShoots;
    public float shootStrength;


    public virtual Vector2 ShootOneInFixedUpdate(EngineController engine)
    {

        Vector3 shoot = engine.transform.TransformDirection(Vector3.up);
        var force = shoot.normalized * shootStrength* Time.fixedDeltaTime;
        engine.effectedParent.AddForceAtPosition(force, engine.transform.position);
        return force;
        //print("Shoot from " + gameObject.name + ", " + shoot.normalized*shootStrength);
    }
}
