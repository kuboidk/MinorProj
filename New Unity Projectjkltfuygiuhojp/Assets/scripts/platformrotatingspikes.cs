using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformrotatingspikes : MonoBehaviour
{
    public float degrees = 80f;
    public int eulerAngZ = 0;
    public bool isForward;
    public int totaltime = 5;
    public int time;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        time = totaltime;


    }

    // Update is called once per frame
    void Update()
    {
      //  if (time > 0)
      //  {
           
    //    }
        eulerAngZ = (int)transform.localEulerAngles.z;
       
        if (eulerAngZ == 180 )
        {
            isForward = true;


        }
        if (eulerAngZ == 0)
        {
            isForward = true;


        }
        if (isForward)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            time -= 1;
            if (time == 0)
            {
                isForward = false;
                time = totaltime;
            }
        }

        if (!isForward)
        {
            transform.Rotate(Vector3.forward * -degrees * Time.deltaTime);
            
        }
    }  
}

