using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetCar : MonoBehaviour
{
    float elapsedtime;
    Checkpoints checkpoints;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        checkpoints = GetComponent<Checkpoints>();
    }
    private void Update()
    {
        if (rb.velocity.magnitude <= 1)
        {
            elapsedtime = elapsedtime + Time.deltaTime;
        }
        else
        {
            elapsedtime = 0;
        }
        if (elapsedtime > 5)
        {
            gameObject.transform.position = checkpoints.PrevCheckpoint.transform.position;
        }
    }
}
