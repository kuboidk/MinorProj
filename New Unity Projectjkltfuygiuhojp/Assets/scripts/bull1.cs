using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bull1 : MonoBehaviour
{

	public float speed = 20f;
	public float peed = 25f;
	public int givedamage = 50;
	public Rigidbody2D rb;
	

	// Use this for initialization
	void Start()
	{
		
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//forthebarrl forthebarrl = col.GetComponent<forthebarrl>();
		justgodown justgodown = col.GetComponent<justgodown>();
		if (justgodown != null)
		{
			justgodown.fxn( peed);
		}
		damage damage = col.GetComponent<damage>();
		if (damage != null)
		{
			damage.damagefxn(givedamage);
		}
        Destroy(gameObject);
	}

}