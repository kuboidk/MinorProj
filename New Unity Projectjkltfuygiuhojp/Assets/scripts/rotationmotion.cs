using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationmotion : MonoBehaviour
{
    // Start is called before the first frame update
    public float degrees = 80f;
  

    
    void Start()
    {
    
        //  isForward = true;
    }


    void Update()
    {
  
        

      
            transform.Rotate(Vector3.forward * degrees * Time.deltaTime);
       

    }
}
