using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justgodown : MonoBehaviour
{
   // public float maxdownpos = 6.439946f;
    public Rigidbody2D rb;
    public float peed = 9.8f;
    public bool canfell;
    public BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
     //   gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        canfell = false;
    }

    // Update is called once per frame
    void Update()
    {
        //  fxn();
        boxCollider2D.size = new Vector3(0.05f, 3.6f, 0);
        if (canfell)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            rb.velocity = transform.up * -peed * Time.deltaTime;
        }
        if (!canfell)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    public void fxn(float peed)
    {
        canfell = true;
        boxCollider2D.size = new Vector3(0f, 0f, 0f);
        // rb.velocity = transform.up * -peed * Time.deltaTime;
        //   if (rb.position.y < 6f)
        // {

        //      gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        // }
        //transform.Translate(0, -Time.deltaTime * peed, 0);
        // Physics2D.gravity = new Vector2(0, -peed);
    }
}

//   Physics2D.gravity = new Vector2(0, 9.8f);
//6.37
 
           
            // Application.Quit();
        