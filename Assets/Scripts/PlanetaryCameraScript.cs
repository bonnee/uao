using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetaryCameraScript : MonoBehaviour
{

	public GameObject baseObject;
	public GameObject player;
	public GameObject playerMark;

	private Vector2 offset;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		offset = baseObject.transform.position - player.transform.position;
		float zoom = offset.magnitude;

		Vector2 lerp = Vector2.Lerp (baseObject.transform.position, player.transform.position, 0.5f);
		Vector3 position = new Vector3 (lerp.x, lerp.y, -zoom);
		transform.position = position;

		//transform.position = -new Vector3 (offset.x, offset.y, zoom);

		playerMark.transform.localScale = new Vector3 (zoom/2000, zoom/2000, 1);
	}
}
