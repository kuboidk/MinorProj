using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuttingplatforms : MonoBehaviour
{
    public Rigidbody2D rb;
    public float peed = 9.8f;
    public bool canfell;
  public BoxCollider2D boxCollider2D;
    public Transform other;
    // Start is called before the first frame update
    void Start()
    {
     boxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       boxCollider2D.size = new Vector3(0.05f, 3.6f, 0);
        if (canfell)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            // rb.velocity = transform.up * -peed * Time.deltaTime;
            transform.Translate(0, Time.deltaTime * -peed, 0);
        }
        if (!canfell)
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "buzzcut")
        {
            //  Destroy(col.gameObject);
            canfell = true;
            boxCollider2D.size = new Vector3(0f, 0f, 0f);
        }
       
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.name == "kubo")
        {
            other.transform.parent = transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.name == "kubo")
        {
            other.transform.parent = null;
        }

    }
    }
