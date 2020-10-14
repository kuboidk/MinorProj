using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIscript2 : MonoBehaviour
{
    private enum enemyStates
    {
        Idel,
        Run,
        Attack,
        Hurt,
        Dead,
        Jump,
    }
    [SerializeField]  enemyStates currentState;
    [SerializeField] float followRange = 12f;
    [SerializeField]  float attackRang = 3f;
    [SerializeField]  float speedOrignal = 2f;
    [SerializeField] float speed = 2f;
    [SerializeField]  float distanceFromPortal = 1f;
    public Transform kuboObject;
    public Vector2 target;
    public Animator animator;
    [SerializeField]  Rigidbody2D rb;
    [SerializeField]  bool isFliped = false;
    [SerializeField]  bool canFollow = false;
    public GameObject playerObject;
    [SerializeField]  int damage = 30;
    [SerializeField]  bool isAttacking = false;
    [SerializeField]  bool ishurt = false;
    [SerializeField]  int maxHealth = 150;
    [SerializeField]  int currentHealth;
    [SerializeField]  Transform portal1;
    [SerializeField] Transform portal2;
    public int takeDamageAmount = 30;
    [SerializeField] private SpriteRenderer spriteRendrerObj;
   
    [SerializeField]  int rayDistance = 0;
    [SerializeField]  LayerMask jumpLayer;
    [SerializeField] float jumpBoost = 3f;
    [SerializeField]  Transform point;
    [SerializeField]  Transform point2;
    [SerializeField]  float radius;
    [SerializeField]  bool isGrounded = false;
    //  [SerializeField] private BoxCollider2D boxCollider2D ;
    private RaycastHit2D hit;
    void Start()
    {
        speed = speedOrignal;
        currentHealth = maxHealth;
        currentState = enemyStates.Idel;
        rb = GetComponent<Rigidbody2D>();
        Vector2 target = new Vector2(kuboObject.position.x, rb.position.y);
        spriteRendrerObj = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        isAttacking = false;
        flipFunction();
        conditions();
        portalFunction();
        jumpFunction();
     
        if (isGrounded)
        {
            speed = speedOrignal;
            animator.SetBool("Jump", false);
        
        }
        //canFollow = false;     
        //isAttacking = true;

        switch (currentState)
        {
            default:
            case enemyStates.Idel:
                {

                }
                break;
            case enemyStates.Run:
                {
                    runFunction();
                }
                break;
            case enemyStates.Attack:
                {
                    animator.SetTrigger("Attack");
                }
                break;
            case enemyStates.Hurt:
                {

                }
                break;
            case enemyStates.Dead:
                {

                }
                break;
            case enemyStates.Jump:
                {

                }
                break;

        }
    }
    private void FixedUpdate()
    {
        //    RaycastHit2D hit;
        if (Physics2D.Raycast(transform.position, transform.forward, rayDistance))
        {
          //  Debug.Log("Did Hit");
        }
            
    }
    void runFunction()
    {

        animator.SetInteger("run", 1);
        Vector2 target = new Vector2(kuboObject.position.x, rb.position.y);
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }
    void attackFunction()
    {
        animator.SetTrigger("Attack");
    }

    void attackFunctionActual()
    {
     
        if (!canFollow && isAttacking)
        {
            playerObject.GetComponent<kubo>().damagefxn(damage);
        }
    }
    public void takeDamageFunction(int takeDamageAmount)
    {
        currentHealth = currentHealth - takeDamageAmount;
        animator.SetTrigger("hurt");

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void jumpFunction()
    {
        Collider2D[] jumparry = Physics2D.OverlapCircleAll(point.position, radius, jumpLayer);
        Collider2D[] jumparry2 = Physics2D.OverlapCircleAll(point2.position, radius, jumpLayer);
        foreach (Collider2D floor in jumparry2)
        {
            if (isGrounded)
            {
                speed = speed + 1f;
                isGrounded = false;
                rb.velocity = new Vector2(rb.velocity.x, jumpBoost +2f);
                animator.SetBool("Jump", true);
            }
        }
        foreach (Collider2D floor in jumparry)
        {
            if(isGrounded)
            {
                speed = speed + 1f;
                isGrounded = false;
                rb.velocity = new Vector2(rb.velocity.x , jumpBoost);
                animator.SetBool("Jump",true);
            }
        }
    }
    
    void OnCollisionStay2D()
    {
        isGrounded = true;
    }
   
    void OnDrawGizmosSelected()
    {
        if (point == null)
            return;
        Gizmos.DrawWireSphere(point.position, radius);
       
    }
    void conditions()
    {
        if (Vector3.Distance(kuboObject.position, transform.position) < followRange)
        {
            canFollow = true;

        }
        if (Vector3.Distance(kuboObject.position, transform.position) > followRange)
        {
            canFollow = false;

        }
        if (canFollow)
        {
            currentState = enemyStates.Run;
        }
        if (Vector3.Distance(  transform.position, kuboObject.position) < attackRang)
        {
            currentState = enemyStates.Attack;
            canFollow = false;
            isAttacking = true;
        }
        if (!canFollow && !isAttacking)
        {
            currentState = enemyStates.Idel;
            animator.SetInteger("run", 0);
        }


    }
    void portalFunction()
    {

        if (Vector3.Distance(kuboObject.transform.position, portal2.transform.position) < 13f)
        {
            if (Vector3.Distance(gameObject.transform.position, portal1.transform.position) < distanceFromPortal)
            {
                transform.localPosition = portal2.transform.position;
            }
            transform.localPosition = transform.localPosition;
        }
        else if (Vector3.Distance(kuboObject.transform.position, portal1.transform.position) < 13f)
        {
          if (Vector3.Distance(gameObject.transform.position, portal2.transform.position) < distanceFromPortal)
           {
            transform.localPosition = portal1.transform.position;
           }
            transform.localPosition = transform.localPosition;
        } 
    }
 
    void flipFunction()
    {
        if (kuboObject.position.x > rb.position.x && !isFliped || kuboObject.position.x < rb.position.x && isFliped)
        {
            Vector3 orignalScale = transform.localScale;
            orignalScale.x *= -1;
            transform.localScale = orignalScale;
            isFliped = !isFliped;
        }

    }
}
