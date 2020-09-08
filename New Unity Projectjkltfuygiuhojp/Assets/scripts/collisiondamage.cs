using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class collisiondamage : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "kubo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            // Destroy(col.gameObject);
            //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //  Application.Quit();
        }
    }
}
