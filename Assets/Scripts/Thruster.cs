using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : MonoBehaviour
{
	public Vector3 direction = new Vector3 (1, 0, 0);
	public float multiplier;

	private ParticleSystem ps;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		ps = GetComponent<ParticleSystem> ();
		rb = GetComponentInParent<Rigidbody2D> ();
	}

	public void fire ()
	{
		rb.AddForceAtPosition (rb.transform.TransformDirection (multiplier * direction), ps.transform.position);
		ps.Play ();
	}

	public void stop()
	{
		if (ps.main.loop && ps.isPlaying) {
			ps.Stop ();
		}
	}
}
