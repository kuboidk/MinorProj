using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorscript : MonoBehaviour
{
    public BoxCollider2D box2D;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        box2D.size = new Vector3(1.791856f, 6.108172f, 0);
        box2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void doorfxn()
    {
        //Destroy(gameObject);
        box2D.size = new Vector3(0f, 0f, 0f);
        animator.SetInteger("door", 1);

    }

}
