using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpingFeet : MonoBehaviour
{
    // Start is called before the first frame update
    public kubo kuboSceipt;
    public GameObject kuboObject;
    void Start()
    {
        kuboSceipt = kuboObject.GetComponent<kubo>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnCollisionStay2D()
    {
        kuboSceipt.isGrounded = true; 

    }
}
