using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalProperties : MonoBehaviour
{
	public bool gravityAffected;
	public Vector2 velocity;

	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		if(gravityAffected)
			rb.velocity = velocity;
	}
}