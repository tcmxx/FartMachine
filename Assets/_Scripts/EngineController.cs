using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EngineController : MonoBehaviour {

    public Rigidbody2D effectedParent;
    public Transform forcePosition;

    public EngineData engineData;
    public ShootEvent onShootOnce;
    public UnityEvent onKeepShootStart;
    public UnityEvent onKeepShootStop;


    public bool WillShootNext { get; private set; } = false;
    public bool IsKeepShooting { get; private set; } = false;

    protected int skippedCounter = 0;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        bool shoot = false;
        if (WillShootNext && skippedCounter >= engineData.minFixedUpdateBetweenShoots)
        {
            shoot = true;
        }
        else
        {
            skippedCounter++;
        }

        if (IsKeepShooting)
        {
            WillShootNext = true;
        }
        else
        {
            WillShootNext = false;
        }

        if (shoot)
        {
            var f = engineData.ShootOneInFixedUpdate(this);
            onShootOnce.Invoke(f);
            skippedCounter = 0;
        }
    }

    public void StartShooting()
    {
        //print("Start Shooting from " + gameObject.name);
        IsKeepShooting = true;
        WillShootNext = true;
        onKeepShootStart.Invoke();
    }

    public void StopShooting()
    {
        //print("Stop Shooting from " + gameObject.name);
        IsKeepShooting = false;
        WillShootNext = false;
        onKeepShootStop.Invoke();
    }

    public void TryShootOnce()
    {
        //print("Try Shooting once from " + gameObject.name);
        WillShootNext = true;
    }

    protected void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(forcePosition.position, 0.1f);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.1f);
    }

}

[Serializable]
public class ShootEvent: UnityEvent<Vector2>
{

}