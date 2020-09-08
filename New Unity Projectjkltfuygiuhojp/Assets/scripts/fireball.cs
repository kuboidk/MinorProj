using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 20f;
  //  public float peed = 25f;
   public int givedamage = 50;
    public Rigidbody2D rb;
    //public bool fli = false;
   // public damage dm;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

     
            rb.velocity = transform.right * -speed;
     
    }
    void OnTriggerEnter2D(Collider2D col)
    { 
        kubo kubo = col.GetComponent<kubo>();
        if (kubo != null)
        { 
            kubo.damagefxn(givedamage);
           
        }
        Destroy(gameObject);

        //   Destroy(gameObject);
    }
  //  void Update()
  //  {
   //     if (Time.time > 10f)
    //    {
    //        Destroy(gameObject);
     //   }
   // }
    // if (dm.fli == false)
    //  {
    //      rb.velocity = transform.right* speed;
    //  }
    //  if (dm.fli)
    //   {
    //       rb.velocity = transform.right* -speed;
    //  }


    // void dfxn()
    // {

    //   

    //  }
    //void OnTriggerEnter2D(Collider2D col)
    //	{


    //Destroy(gameObject);
    //}
}


