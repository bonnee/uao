using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gravity : MonoBehaviour
{
	const double G = 6.67408 * 10e-11;

	public ulong mass;

	private Rigidbody2D planet;

	// Use this for initialization
	void Start ()
	{
		planet = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
		foreach (UniversalProperties go in UnityEngine.Object.FindObjectsOfType<UniversalProperties>()) {
			if (go.gravityAffected) {
				
				Rigidbody2D rb = go.GetComponent<Rigidbody2D> ();

				Vector2 offset = rb.position - planet.position;
				float dist = offset.magnitude;

				//go.GetComponent<UniversalProperties>(). = dist-planet.transform.localScale.x/2;

				if (dist >= 0)
					rb.AddForce ((float)-G * ((rb.mass * mass * offset.normalized) / dist));
			}
		}
	}
}
