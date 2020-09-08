using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

	public float speed = 20f;
	public int givedamage = 50;
	public Rigidbody2D rb;
	public GameObject impactEffect;

	// Use this for initialization
	void Start()
	{
		rb.velocity = transform.right * speed;
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		damage damage = col.GetComponent<damage>();
		if (damage != null)
		{
			damage.damagefxn( givedamage);
		}

		Instantiate(impactEffect, transform.position, transform.rotation);

		Destroy(gameObject);
	}

}