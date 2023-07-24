using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sledgeMove : MonoBehaviour
{
    Transform tr;
    public float moveSpeed = 1.0f;
    private float h = 0.0f;
    private float v = 0.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 moveDir = (Vector3.forward * v)
              + (Vector3.right * h);

        tr.Translate(moveDir * Time.deltaTime * moveSpeed);
    }

}

