using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buzzcutter : MonoBehaviour
{

    public Rigidbody2D rb;
    public float xpos = 158.34f;
    public float ypos = 0f;
   // public float zpos = 0f;
    public float eed = 3f;
    public LayerMask GetLayerMask;
    public Transform point;
    public float range = 0.5f;
    public bool pingpong = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = new Vector3(Mathf.PingPong(Time.time, eed) + xpos, ypos, zpos);
        xpos = transform.position.x;
        ypos = transform.position.y;
        onu();
       if (pingpong && xpos < 174f )
       {
            //  transform.position = new Vector3(Mathf.PingPong(Time.time, eed) + xpos, ypos, zpos);
            transform.Translate(Time.deltaTime * eed, 0, 0);
       //     Debug.Log("pk");
        }

    }
    void onu()
    //  void onu(delay : float)
    {


        Collider2D[] hiti = Physics2D.OverlapCircleAll(point.position, range, GetLayerMask);
        foreach (Collider2D kubo in hiti)
        {
            //  transform.position = new Vector3(Mathf.PingPong(Time.time, eed) + xpos, ypos, zpos);
            pingpong = true;
           // transform.Translate(Time.deltaTime * eed, 0, 0);
        }
    }
    void OnDrawGizmosSelected()
    {
        if (point == null)
            return;
        Gizmos.DrawWireSphere(point.position, range);
    }
}
