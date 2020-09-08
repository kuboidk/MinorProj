using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Bosslavaincrement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D golem;
    public Rigidbody2D bossdeath;
    public float upSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        golem= GetComponent<Rigidbody2D>();
        bossdeath = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, upSpeed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "kubo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (collision.gameObject.name == "golem")
        {
           
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name == "bossdeath")
        {

            Destroy(collision.gameObject);
        }
    }
}
