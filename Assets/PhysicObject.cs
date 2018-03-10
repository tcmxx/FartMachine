using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PhysicObject : MonoBehaviour {

    public float defaultDrag;
    public float defaultAngularDrag;


    public FloorBasic currentFloor = null;

    public Rigidbody2D Body { get; private set; }

    private void Awake()
    {
        Body = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Body.drag = defaultDrag;
        Body.angularDrag = defaultAngularDrag;
    }
}
