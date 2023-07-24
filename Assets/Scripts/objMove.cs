using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objMove : MonoBehaviour
{
    public enum MoveType
    {
        WAY_POINT
    }

    public MoveType moveType = MoveType.WAY_POINT;
    public float speed = 6.0f;
    public float damping = 3.0f;

    private Transform tr;

    private Transform[] points;
    public int nextIdx = 1;

    bool istrigger = false;

    void Start()
    {
        tr = GetComponent<Transform>();

        points = GameObject.Find("WayPointGroup").GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        MoveWayPoint();
    }

    void MoveWayPoint()
    {
        Vector3 direction = points[nextIdx].position - tr.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);

        tr.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("WAY_POINT"))
        {
            if(istrigger == false)
            {
                nextIdx = (++nextIdx >= points.Length) ? 1 : nextIdx;
            }

            istrigger = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("WAY_POINT"))
        {
            istrigger = false;
        }
    }

}
