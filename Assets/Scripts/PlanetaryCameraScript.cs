using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryCameraScript : MonoBehaviour {

	public GameObject baseObject;
	public GameObject player;

	private Vector2 offset;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		offset = baseObject.transform.position - player.transform.position;

		transform.position = -new Vector3 (offset.x, offset.y, offset.magnitude+baseObject.transform.localScale.x);
	}
}
