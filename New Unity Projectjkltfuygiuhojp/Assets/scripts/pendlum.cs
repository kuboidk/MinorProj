using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class pendlum : MonoBehaviour
{
    public float deg = -80f;
    public float degrees = 80f;
    public float eulerAngZ = 90f;
    public bool isForward;


    void Start()
    {
        isForward = true;
    }


    void FixedUpdate()
    {
        eulerAngZ = transform.localEulerAngles.z;
        if (eulerAngZ <= 90f)
        {
            isForward = true;

        }
        if (eulerAngZ >= 270f)
        {
            isForward = false;

        }

        if (isForward)
        {
            transform.Rotate(Vector3.forward * degrees * Time.deltaTime);
        }
        else if (!isForward)
        {
            transform.Rotate(Vector3.forward * deg * Time.deltaTime);

        }
    }
}

