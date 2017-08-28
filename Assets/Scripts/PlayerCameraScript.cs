using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{

	public GameObject target;

	private Vector3 init;
	private Vector3 offset;

	// Use this for initialization
	void Start ()
	{
		init = transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate ()
	{
		float zoom = (transform.position - target.transform.position).magnitude;

		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, -zoom);

		transform.rotation = target.transform.rotation;
	}
}
