using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
	public float MoveSpeed;
	public float RotationSpeed;
	public float thrust;

	public Text altitude;
	public Text velocity;

	private Rigidbody2D rb;
	private Thruster mainRocket;
	private UniversalProperties props;

	private List<ParticleSystem> rcs;

	private bool boost;

	private float alt, apo, peri;

	// Use this for initialization
	void Start()
	{
		props = GetComponent<UniversalProperties>();

		boost = false;

		rb = GetComponent<Rigidbody2D>();

		mainRocket = transform.Find("Nozzle").transform.Find("Rocket").GetComponent<Thruster>();

		rcs = new List<ParticleSystem>();
		foreach (ParticleSystem ps in GetComponentsInChildren<ParticleSystem>())
		{
			if (ps.name.Contains("RCS"))
			{
				ps.GetComponent<Thruster>().multiplier = MoveSpeed;
				rcs.Add(ps);
			}
		}
		alt = Mathf.Round(Vector3.Distance(rb.position, Vector3.zero));
		apo = alt;
		peri = alt;
	}

	void FixedUpdate()
	{
		float horiz = Input.GetAxis("Horizontal");
		float verti = Input.GetAxis("Vertical");

		float rotation = 0;

		if (Input.GetKey(KeyCode.J))
			rotation = 1;
		else if (Input.GetKey(KeyCode.K))
			rotation = -1;

		Vector3 direc = new Vector3(verti, -horiz, rotation);

		if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
		{
			boost = true;

			if (verti > 0)
			{
				mainRocket.fire();
			}
			else
			{
				mainRocket.stop();
			}
		}
		else
		{
			boost = false;
			mainRocket.stop();
		}

		foreach (ParticleSystem thruster in rcs)
		{
			Thruster rc = thruster.GetComponent<Thruster>();

			float n = Vector3.Dot(rc.direction, direc);
			bool rotOver = (rotation > 0 && rc.direction.z > 0) || (rotation < 0 && rc.direction.z < 0);

			if ((n > 0.5 || rotOver) && !(boost && rc.direction.x > 0))
				rc.fire();
		}
	}

	void LateUpdate()
	{
		float curalt = Mathf.Round(Vector3.Distance(rb.position, Vector3.zero));

		if (curalt > alt)
			apo = curalt;
		if (curalt < alt)
			peri = curalt;
		
		alt = curalt;

		altitude.text = "Alt: " + alt + " m | Apo: " + apo + "m | Peri: " + peri + "m";
		//velocity.text = "Vel: " + Mathf.Round (rb.velocity.magnitude) + " m/s";
	}

	static void AddRelativeForceAtPosition(Rigidbody2D body, Vector2 force, Vector2 position)
	{
		body.AddForceAtPosition(body.transform.TransformDirection(force), position);
	}
}
