using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class EnemyAIscript1 : MonoBehaviour
{
    private enum enemyStates
    {
        Idel,
        Run,
        Attack,
        Dead,
      
    }
    [SerializeField]  enemyStates currentState;
    [SerializeField]  float followRange = 12f;
    [SerializeField]  float attackRang = 3f;
    [SerializeField]  float speed = 2f;
     public Transform kuboObject;
    public Vector2 target;
     public Animator animator;
    [SerializeField]  Rigidbody2D rb;
    [SerializeField]  bool isFliped = false;
    [SerializeField]  bool canFollow = false;
    public GameObject playerObject;
    [SerializeField] public  int damage = 30;
    [SerializeField]  bool isAttacking = false;
    [SerializeField]  bool ishurt = false;
    [SerializeField]  int maxHealth  = 150 ;
    [SerializeField]  int currentHealth ;
     public int takeDamageAmount = 30;
    [SerializeField]  SpriteRenderer spriteRendrerObj;
    [SerializeField]  float iColour = 20f;
    [SerializeField]  float fColour;
    [SerializeField] GameObject coin;
     bool isDead = false;
    [SerializeField] [Range(0f, 1f)] float t;
  //  [SerializeField] public int timer = 50;
//    [SerializeField] private Transform petrol1;
//    [SerializeField] private Transform petrol2;
    [SerializeField] bool forwardPetrol = true;
    void Start()
    {
      
        fColour = iColour;
        currentHealth = maxHealth;
        currentState = enemyStates.Idel;
        rb = GetComponent<Rigidbody2D>();
        Vector2 target = new Vector2(kuboObject.position.x, rb.position.y);
        spriteRendrerObj = GetComponent<SpriteRenderer>();
       


    }
    void Update()
    {
        isAttacking = false;
        if (canFollow)
        {
            flipFunction();
        }
         conditions();
     //   patrolFunction();

        if (spriteRendrerObj.color == Color.red)
        {
            fColour -= 1f;
            if (fColour <= 0f)
            {
                spriteRendrerObj.color = Color.white;
                fColour = iColour;
            }
        }
        switch (currentState) {
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
                    attackFunction();
                }
                break;
            case enemyStates.Dead:
                {
                    deathFunction();
                }
                break;


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
        animator.SetTrigger("attack");
    }

    void attackFunctionActual()
    {
          playerObject.GetComponent<kubo>().damagefxn(damage);
    }
    public void takeDamageFunction( int takeDamageAmount)
    {
        currentHealth = currentHealth - takeDamageAmount;
        spriteRendrerObj.color = Color.red;
        
    
        if (currentHealth <= 0)
        {
            currentState = enemyStates.Dead;
            isDead = true;
           
        }
     
    }

    void conditions()
    {
        if (!isDead)
        {
            if ((kuboObject.position.x  - transform.position.x) < followRange &&  

               Mathf.Abs( Mathf.Abs(kuboObject.position.y) - Mathf.Abs(transform.position.y)) <  1f  )
               
            {
                canFollow = true;

            }
            if ( (kuboObject.position.x - transform.position.x) > followRange ||
                Mathf.Abs(Mathf.Abs(kuboObject.position.y) - Mathf.Abs(transform.position.y)) > 1f)
            {
                canFollow = false;

            }

            
            if (canFollow)
            {
                currentState = enemyStates.Run;
            }
            if (Vector3.Distance(kuboObject.position, transform.position) < attackRang)
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
        
    }

    void deathFunction()
    {
        animator.Play("idel");
         spriteRendrerObj.color = Color.black;
        int coinDrop = Random.Range(2, 7);
       
        for (int i = 0; i < coinDrop; i++)
        {
            Instantiate(coin, transform.position,Quaternion.identity);
         
        }
        Destroy(gameObject, 0f);



    }

    void flipFunction()
    { 
      if(kuboObject.position.x > rb.position.x && !isFliped || kuboObject.position.x < rb.position.x && isFliped) 
        {
            Vector3 orignalScale = transform.localScale;
            orignalScale.x *= -1;
            transform.localScale = orignalScale;
            isFliped = !isFliped;
        }
    
    }
}
