using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTree : MonoBehaviour {

	public GameObject stalk;
	public GameObject leaves;
	public Transform tesselHolder;

	public bool isGrowing = false;
	public bool isLeaves;

	private float randomRotation;
	private float time;

	void Start ()
	{
		InvokeRepeating ("RandomRotation", 1.5f, 0.5f);
		tesselHolder = GameObject.FindGameObjectWithTag ("TesselHolder").transform;
	}

	void Update ()
	{
		//transform.position = new Vector2 (Random.insideUnitCircle.x, transform.position.y);

		transform.rotation = Quaternion.Euler (new Vector3 (0,0, randomRotation));
		if (Input.GetKey (KeyCode.Space) && !isGrowing) {
			isGrowing = true;
		}

		if (isGrowing) {
			Transform currentStalk;
			transform.Translate (transform.up/20);
			currentStalk = Instantiate (stalk, new Vector2 (transform.position.x + Random.Range (-0.25f, 0.25f), transform.position.y), Quaternion.identity, tesselHolder).transform;
			currentStalk.localScale = new Vector3 (currentStalk.localScale.x, currentStalk.localScale.y, currentStalk.localScale.z);
			if (isLeaves && isGrowing) {
				InvokeRepeating ("CreateLeaves", 0.1f, 0.1f);
				isLeaves = false;
			}
		}
	}

	void RandomRotation ()
	{
		randomRotation = Random.Range (-45f, 45f);
	}

	void CreateLeaves ()
	{
		Instantiate (leaves, new Vector2 (transform.position.x + Random.Range (-2f, 2f), transform.position.y + Random.Range (-2f, 2f)), Quaternion.Euler (new Vector3 (0,0, Random.Range (-90, 90))), tesselHolder);
	}
}
