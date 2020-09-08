using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class damage : MonoBehaviour
{
    public bool iswalking = false;
    public float eulerAngZ = 0f;
    public int give = 0;
    public float range = 0.5f;
    public float bange = 0.5f;
    public float cmon = 0.5f;
    public float followrange = 0.5f;
    public float speed = 0.1f;
    public LayerMask GetLayerMask;
    public LayerMask floorlayer;
    public LayerMask followlayer;
    public LayerMask emptyobject;
    public Animator animator;
    public Transform point;
    public Transform jumprange;
    public Transform koint;
    public Transform noint;
    public Transform followpoint;
    public Transform get;
    public float attackrate = 2f;
    float nextattacktime = 0f;
    int currenthealth;
    public int maxhealth = 300;
    public Vector2 target;
    public  Vector2 position;
    public bool fli = false;
    public bool isGrounded = false;
    public float jumpboost =100f;
    public bool canfollow = false;
    public float peed = 2f;
    public float hspeed = 2f;
    public float hjump = 3f;
    public GameObject bullprefeb;
    public GameObject bul2fab;
    public int bulletcount = 100;
    public bool canthrough = true;
    public bool canjump = true;
    public bool canverticlejump = true;
    public bool colliding = false;
    public Rigidbody2D rb;
    public bool isdetecting = false;
    void Start()
    {
        rb =  GetComponent<Rigidbody2D>();

        fli = false;
        animator = GetComponent<Animator>();
        currenthealth = maxhealth;
        target = new Vector2(-8f, rb.position.y);
        position = gameObject.transform.position;

    }
    void Update()
    {
        target = new Vector2(-8f, rb.position.y);
        if (canverticlejump == false)
        {
            if (fli == false)
            {
                transform.Translate(-hspeed * Time.deltaTime, hjump, 0);
            }
            if (fli == true)
            {
                transform.Translate(hspeed * Time.deltaTime, hjump, 0);
            }
            canverticlejump = true;
        }

       if (get != null)
        {
           if (rb.position.y < get.position.y )
            {
                canjump = true;

            }
           // if (rb.position.y > get.position.y)
           else {
                canjump = false;
            }
       }
     

        isdetecting = false;
        canthrough = true;
        canfollow = false;

        
        flip();
        jump();
        nonu();
        verticlejump();

        if (!canfollow || colliding)
        {
            animator.SetInteger("run", 0);
        }
            if (canfollow && !colliding )
        {
            animator.SetInteger("run", 1);
            if (target != null)
            {
                Vector2 myVector = new Vector2(get.position.x,rb.position.y);
            myVector = GameObject.Find("kubo").transform.position;
            target = myVector;
            
                transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
            }
        }

        if (Time.time >= nextattacktime)
        {
            onu();
            if (canthrough)

            {
                if (!fli)
                {
                    Shoot();
                }
                if (fli)
                {
                    Shoot2();
                }
               
            }
            nextattacktime = Time.time + 1f / attackrate;
        }
    }
    void nonu()
  
    {
        Collider2D[] foll = Physics2D.OverlapCircleAll(followpoint.position, followrange, followlayer);
        foreach (Collider2D kubo in foll)
        {
            canfollow = true;
        }

    }
    void onu()
    {

        Collider2D[] hiti = Physics2D.OverlapCircleAll(point.position, range, GetLayerMask);
        foreach (Collider2D kubo in hiti)
        {
            canthrough = false;
            animator.SetTrigger("attackgolem");
            kubo.GetComponent<kubo>().damagefxn(give);
        }

    }
    void jump()

    {
        Collider2D[] jumparry = Physics2D.OverlapCircleAll(koint.position, bange, floorlayer);
        foreach (Collider2D floor in jumparry)
        {
            isdetecting = true;
            if ( isGrounded && canjump)
            {
                isGrounded = false;
                if (fli == false)
                {
                    transform.Translate(-peed * Time.deltaTime, jumpboost, 0);
                }
                if (fli == true)
                {
                    transform.Translate(peed * Time.deltaTime, jumpboost, 0);
                }
            }
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "kubo")
        {
            colliding = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "kubo" )
        {
            colliding = false;
        }
    }
    void verticlejump()

    {
        Collider2D[] vjump = Physics2D.OverlapCircleAll(jumprange.position, cmon, emptyobject);
        foreach (Collider2D empty in vjump)
        {
            canverticlejump = false;
            
        }

    }
    void OnDrawGizmosSelected()
    {
        if (point == null)
            return;
        Gizmos.DrawWireSphere(point.position, range);
        Gizmos.DrawWireSphere(koint.position, bange);
        Gizmos.DrawWireSphere(followpoint.position, followrange);
        Gizmos.DrawWireSphere(jumprange.position, cmon );
    }
    public void damagefxn(int givedamage)
    {
        currenthealth -= givedamage;


        if (currenthealth <= 0)
        {
            Debug.Log("ded ");
            Destroy(gameObject);
        }
    }

   void flip()
    {
        if (get != null)
        {

            if (transform.position.x < get.position.x && !fli || transform.position.x > get.position.x && fli)
            {
                fli = !fli;
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;

            }
        }
    }
    void OnCollisionStay2D()
    {
        isGrounded = true;
    }
    void Shoot()
    {
        if (bulletcount > 0)
        {
            Instantiate(bullprefeb , noint.position, noint.rotation);
            bulletcount = bulletcount - 1;
        }

    }
    void Shoot2()
    {
        if (bulletcount > 0)
        {
            Instantiate(bul2fab, noint.position, noint.rotation);
            bulletcount = bulletcount - 1;
        }

    }
}
