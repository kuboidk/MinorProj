using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class kubo : MonoBehaviour
{
    public LayerMask GetLayerMaskdoor;
    public Transform pointdoor;
    public float rangedoor = 0.5f;
    public BoxCollider2D boxCollider2D;
    public healthbarscript healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;

    private int count;
    public Text countText;
    // private bool walk = false;
    public AudioClip audioClip;
    public float jumpboost = 100f;
    public float maxdownpos = -5f;
    public float speed = 5f;
    //private bool isJumping = false;
    public Rigidbody2D rb;
    public int give = 10;
    public float range = 0.5f;
    public LayerMask GetLayerMask;
    //  public LayerMask GetLayerMaskforhead;
    public Transform point;
    // public Transform headpoint;
    //  public float headpointradius = 0.3f;
    public Transform other;
    public float attackrate = 2f;
    float nextattacktime = 0f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform ping;
    public bool isGrounded;
    private int countweapon;
    public Text weaponcounttext;
    public bool havekunai = false;
    public float ladderspeed = 6f;
    private float orignalgravity = 1f;

    public GameObject jumpingFeet;
    //public 
    public CircleCollider2D circleCollider2D;
    //public bool canstand = true;
    //private bool pingpong = false;
    // Start is called before the first frame update
    //inventory system using array
    // public int[] items; 
    //  public List<int> itemname = new List<int>();
     
    public float levitationspeed = 6f;
    public bool flip = false;
 //   public bool ispressing = false;
    void Start()
    {
        // inventory system 
        orignalgravity = rb.gravityScale;
        boxCollider2D = GetComponent<BoxCollider2D>();
        GetComponent<AudioSource>().playOnAwake = false;
          circleCollider2D= jumpingFeet.GetComponent<CircleCollider2D>(); 
        GetComponent<AudioSource>().clip = audioClip;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        count = 0;
        countweapon = 0;
        SetCountText();
        SetCountTextweapon();

    }


    void Update()
    {

        //  if (rb.velocity.y < 0)
        // {
        //     isGrounded = false;
        //}
        boxCollider2D.size = new Vector2(2f, 3f);
        circleCollider2D.radius = 0.57f;
        boxCollider2D.offset = new Vector2(0, 0.7f);
        circleCollider2D.offset = new Vector2(0.06f, -1.62f);


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            animator.SetInteger("run", 1);
            if (!flip)
            {
                flipfxn();
            }
            animator.SetInteger("run", 1);
            animator.SetInteger("jumpr", 0);
            animator.SetInteger("runjump", 0);
            animator.SetInteger("jumponly", 0);


            if (Input.GetKey(KeyCode.C))
            {
                // boxCollider2D.size = new Vector3(5f, 3f, 0);
                boxCollider2D.size = new Vector2(2f, 2f);
                circleCollider2D.radius = 0.57f;
                boxCollider2D.offset = new Vector2(-0.5f, 0.7f);
                circleCollider2D.offset = new Vector2(0.06f, -0.75f);
                animator.SetBool("slider", true);
            }
            if (isGrounded == false)
            {
                animator.SetInteger("jumpr", 3);
                animator.SetInteger("runjump", 6);

            }
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("slider", false);
            animator.SetInteger("run", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);

            if (flip)
            {
                flipfxn();
            }
            animator.SetInteger("jumpr", 0);
            animator.SetInteger("run", 1);
            animator.SetInteger("runjump", 0);
            animator.SetInteger("jumponly", 0);

            if (Input.GetKey(KeyCode.C))
            {
                boxCollider2D.size = new Vector2(2f, 2f);
                circleCollider2D.radius = 0.57f;
                boxCollider2D.offset = new Vector2(-0.5f, 0.7f);
                circleCollider2D.offset = new Vector2(0.06f, -0.75f);
                animator.SetBool("slider", true);
            }



            if (isGrounded == false)
            {
                animator.SetInteger("jumpr", 3);
                animator.SetInteger("runjump", 6);

            }
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("slider", false);
            animator.SetInteger("run", 0);
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            animator.SetBool("slider", false);

        }


        if (Input.GetKeyUp(KeyCode.E) && count > 3)
        {
            Opendoor();

        }
        if (countweapon <= 0)
        {
            havekunai = false;
        }
        if (havekunai)
        {
            if (!isGrounded && countweapon > 0 && Input.GetKeyDown(KeyCode.Mouse1))
            {
                animator.SetTrigger("jumpthrough");
            }
            else if (countweapon > 0 && Input.GetKeyDown(KeyCode.Mouse1) && isGrounded)
            {
                animator.SetTrigger("through");
            }
        }


        if (Time.time >= nextattacktime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Hitonu();
                nextattacktime = Time.time + 1f / attackrate;
            }

        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            transform.Translate(0, jumpboost, 0);
            isGrounded = false;
            animator.SetInteger("jumponly", 10);
        }

        if (Input.GetKey(KeyCode.Mouse0) && isGrounded)
        {
            animator.SetInteger("attack", 5);
        }
        if (!isGrounded  && Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetInteger("jumpattack", 1);

        }
        if (isGrounded || Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetInteger("jumpattack", 0);
        }
            if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            animator.SetInteger("attack", 0);
        }

        animator.SetBool("hurt", false);

        if (rb.position.y < maxdownpos)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (isGrounded)
        {
            animator.SetInteger("jumponly", 0);
            animator.SetInteger("runjump", 0);
            animator.SetInteger("jumpr", 0);
        }
    }
  //  void OnCollisionStay2D( Collision2D collision2D )
 //   {
     //   if (collision2D.gameObject.name == "jumpingFoot")
       // {
         //   isGrounded = true;
       // }
 //   }
    
     void OnTriggerStay2D(Collider2D col)
    {
        jumpboost = 0f;
        if (col.gameObject.name == "levitator")
        {
            animator.SetInteger("glide", 1);
            rb.velocity = new Vector2(0, levitationspeed);   


        }

        if (col.gameObject.name == "ladder")
        {
            rb.gravityScale = 0f;
           
            if(Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.W))
            {
                animator.SetInteger("climb", 0);

            }

            if ( Input.GetKey(KeyCode.W))
            {
                 // rb.velocity = new Vector2(0, ladderspeed);
                transform.Translate(0, ladderspeed * Time.deltaTime, 0);
                animator.SetInteger("climb", 10);
                animator.SetInteger("climbstop", 0);
            }
             else if (Input.GetKey(KeyCode.S))
            {
               //  rb.velocity = new Vector2(0, -ladderspeed);
                transform.Translate(0, ladderspeed * -Time.deltaTime, 0);
                animator.SetInteger("climb", 10);
                animator.SetInteger("climbstop", 0);
            }
            else
            {
                animator.SetInteger("climbstop", 11);
            }
        }
      
          
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        rb.gravityScale = orignalgravity;
        animator.SetInteger("climbstop", 0);
        animator.SetInteger("climb", 0);
        animator.SetInteger("glide", 0);
        jumpboost = 3f;
    }
    void OnTriggerEnter2D(Collider2D mol)
    {
       
        if (mol.gameObject.name == "Kunai")
        {
            
            Destroy(mol.gameObject);
             havekunai = true;
            countweapon = countweapon +3;
            SetCountTextweapon();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.name == "pong")
        {
             ping= col.gameObject.transform;
            transform.SetParent(ping);
        }
       

        if (col.gameObject.name == "koin")
        {
            Destroy(col.gameObject);
            GetComponent<AudioSource>().Play();
            count = count + 1;
            SetCountText();   
        }
       
    }
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.name == "pong")
        {

            transform.parent = null;
        }
    }

    void SetCountText()
    {
        countText.text = "" + count.ToString();

    }
    void SetCountTextweapon()
    {
        weaponcounttext.text = "" + countweapon.ToString();

    }

    void OnDrawGizmosSelected()
    {
        if (point == null)
            return;
        Gizmos.DrawWireSphere(point.position, range);
      //Gizmos.DrawWireSphere(headpoint.position, headpointradius);
    }
 
public void Hitonu()

    {

        //  animator.SetInteger("attack", 5);
        Collider2D[] door = Physics2D.OverlapCircleAll(point.position, range, GetLayerMask);
       
        foreach (Collider2D creep in door)
        {
            creep.GetComponent<damage>().damagefxn( give);
        }
    }
    public void damagefxn(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetBool("hurt",true);

       if (currentHealth <= 0)
        {
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            //   animator.SetInteger("ded", 9);
            Destroy(gameObject);

        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        countweapon = countweapon - 1;
        SetCountTextweapon();
    }
    public void Opendoor()

    {

        Collider2D[] oor = Physics2D.OverlapCircleAll(pointdoor.position, rangedoor, GetLayerMaskdoor);
        foreach (Collider2D fordoor in oor)
        {
            count = count - 3;
            SetCountText();
            fordoor.GetComponent<doorscript>().doorfxn();
        }
    }

    void flipfxn()
    {            
                Vector3 theScale = transform.localScale;
                theScale.x *= -1;
                transform.localScale = theScale;
               flip = !flip;
    }

}
