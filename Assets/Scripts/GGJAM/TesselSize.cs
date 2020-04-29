using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesselSize : MonoBehaviour {

	// Update is called once per frame
	void Start () {
		transform.localScale = new Vector3 (transform.localScale.x * 5 / (transform.position.y), transform.localScale.y, transform.localScale.z);
	}
}
