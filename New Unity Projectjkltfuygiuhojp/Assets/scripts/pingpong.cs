using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pingpong : MonoBehaviour
{
    public float xpos = 147.36f;
    public float ypos = 0f;
    public float zpos = 0f;
    public float eed = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
  
    private void FixedUpdate()
    {
        transform.position = new Vector3(Mathf.PingPong(Time.time, eed) + xpos, ypos, zpos);
    }
}
