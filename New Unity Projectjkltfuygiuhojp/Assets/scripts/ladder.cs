using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D col)
    {

        //   transform.Translate(0, ladderspeed * Time.deltaTime, 0);
        if (col.gameObject.name == "kubo" && Input.GetKey(KeyCode.W))
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

        }
        else if (col.gameObject.name == "ladder" && Input.GetKey(KeyCode.S))
        {

            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
        else
        {
            col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        }

    }
}
