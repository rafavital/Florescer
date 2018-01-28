using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesselSize : MonoBehaviour {

	// Update is called once per frame
	void Start () {
		transform.localScale = new Vector3 (transform.localScale.x * 10 / (transform.position.y/5), transform.localScale.y, transform.localScale.z);
	}
}
