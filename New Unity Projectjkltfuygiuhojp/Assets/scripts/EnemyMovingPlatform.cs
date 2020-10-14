using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingPlatform : MonoBehaviour
{
    [SerializeField] private float speed  = 1f;
    private bool forward = true;
    [SerializeField] private float initialPos = 0f;
    [SerializeField] private float finalPos = 0f;
    void Update()
    {
        //   speed = Random.Range(0f, 10.0f);
        timeFxn();
    }
    void timeFxn()
    {
        if (forward)
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (!forward)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (transform.position.x <= initialPos)
        {
            forward = true;
        }
        else if (transform.position.x >= finalPos)
        {
            forward = false;
        }
    }
    
}
