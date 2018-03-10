using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class FloorBasic : MonoBehaviour {

    public FloorData floorData;

    public float Drag { get { return floorData.drag; } }
    public float AngularDrag { get { return floorData.angularDrag; } }


    public List<PhysicObject> onFloorObject = new List<PhysicObject>();

    // Use this for initialization
    void Start()
    {

    }


    private void FixedUpdate()
    {
        for(int i = 0; i < onFloorObject.Count; ++i)
        {
            var phyObj = onFloorObject[i];
            if(phyObj == null)
            {
                onFloorObject.RemoveAt(i);
                i--;
            }else if(phyObj.currentFloor == null)
            {
                phyObj.currentFloor = this;
                floorData.OnEnter(phyObj);
            }else if(phyObj.currentFloor == this)
            {
                floorData.OnFixedUpdate(phyObj);
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        var physicObj = collision.GetComponent<PhysicObject>();
        if(physicObj != null && !onFloorObject.Contains(physicObj))
        {
            onFloorObject.Add(physicObj);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var physicObj = collision.GetComponent<PhysicObject>();
        if (physicObj != null && onFloorObject.Contains(physicObj))
        {
            onFloorObject.Remove(physicObj);
            floorData.OnExit(physicObj);
        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < onFloorObject.Count; ++i)
        {
            var phyObj = onFloorObject[i];
            if (phyObj != null && phyObj.currentFloor == this)
            {
                floorData.OnExit(phyObj);
            }
        }
    }
}
