using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class lavacomingupward : MonoBehaviour
{
    // Start is called before the first frame update
    public float yincrement;
    public float orignalincrement;
    public BoxCollider2D boxCollider2D;
    public Rigidbody2D rb; 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        orignalincrement = 0.8f;
        yincrement = orignalincrement;
        boxCollider2D = GetComponent<BoxCollider2D>();
        boxCollider2D.size = new Vector3(24.6f, yincrement , 0);
    }

    // Update is called once per frame
    void Update()
    {
        boxCollider2D.size = new Vector3(24.6f, yincrement, 0);
        yincrement += 0.000f;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "kubo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
         
        }
    }
}
