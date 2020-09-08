using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class buzzsaewscript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float xpos = 0f;
    public float ypos = 0f;
    public float zpos = 0f;
    public float eed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(Mathf.PingPong(Time.time, eed) + xpos, ypos, zpos);
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "kubo")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //  Destroy(col.gameObject);
            //  Application.Quit();
        }
    }
}
