using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class givedamagetoplayer : MonoBehaviour
{
    public float eulerAngZ = 0f;
    public int give = 0;
    public float range = 0.5f;
    public float speed = 5f;
    public LayerMask GetLayerMask;
    public Animator animator;
    public Transform point;

    public float attackrate = 2f;
    float nextattacktime = 0f;
    // public float xpos = 147.36f;
    //  public float ypos = 0f;
    //  public float zpos = 0f;
    // public float eed = 3f;
    // public float eulerAngZ = 0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextattacktime)
        {

            onu();
            nextattacktime = Time.time + 1f / attackrate;

        }
        //  if (eulerAngZ > 21.1046f)
        //  {
        //    animator.SetInteger("run", 1);
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        //   }
        // if (eulerAngZ < 21.1046f)
        //   {
        //       transform.Translate(speed * Time.deltaTime, 0, 0);
        // }
        //      transform.position = new Vector3(Mathf.PingPong(Time.time, eed) + xpos, ypos, zpos);


        //     eulerAngZ = transform.position.x;

        //   transform.Translate(-speed * Time.deltaTime, 0, 0);


        /*  
         * if ()
        {
           GameObject.FindGameObjectWithTag("kubo").transform.position;

         if (eulerAngZ == 13)
        {

        eulerAngZ = transform.position.x;
           if (eulerAngZ != 21.21475f)
         {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
       }*/

        // transform.Translate(-speed * Time.deltaTime, 0, 0);
        // onu();

        // Debug.Log("Gravitation Disabled");
        //  
        //animator.SetTrigger("attackgolem");
        //   }
    }
    void onu()
    //  void onu(delay : float)
    {


        Collider2D[] hiti = Physics2D.OverlapCircleAll(point.position, range, GetLayerMask);
        foreach (Collider2D kubo in hiti)
        {
            animator.SetTrigger("attackgolem");
            kubo.GetComponent<kubo>().damagefxn(give);
            //yield WaitForSeconds(delay);
        }
    }

}
