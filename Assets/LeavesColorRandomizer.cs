using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesColorRandomizer : MonoBehaviour {

	public SpriteRenderer sr;

	// Use this for initialization
	void Start () {
		sr = GetComponent <SpriteRenderer> ();
		sr.color = Random.ColorHSV ();
		//transform.position = new Vector3 (transform.position.x, transform.position.y, Random.Range (0f, 8f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
