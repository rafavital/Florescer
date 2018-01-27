using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTree : MonoBehaviour {

	public GameObject stalkPiece;
	public Transform lastStalk;
	public GameObject treeGenerator;
	public TreeManager treeManager;

	public bool canGrow;

	bool isGrowing;
	bool canRamify = true;

	// Use this for initialization
	void Start () {
		lastStalk.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (lastStalk.position.y >= treeManager.Height) {
			canGrow = false;
		} else {
			canGrow = true;
		}

		if (canGrow && Input.GetKey (KeyCode.Space)) {
			isGrowing = true;
		} else {
			isGrowing = false;
		}

		if (lastStalk.position.y >= treeManager.Height && canRamify) {
			canRamify = false;
		}

		if (isGrowing) {
			lastStalk = Instantiate (stalkPiece, new Vector3 (lastStalk.position.x + Random.Range (-0.15f, 0.15f), lastStalk.position.y), Quaternion.identity, treeManager.transform).transform;
			lastStalk = Instantiate (stalkPiece, new Vector3 (lastStalk.position.x + Random.Range (-0.2f, 0.2f), lastStalk.position.y), Quaternion.identity, treeManager.transform).transform;
			lastStalk = Instantiate (stalkPiece, new Vector3 (lastStalk.position.x + Random.Range (-0.25f, 0.25f), lastStalk.position.y), Quaternion.identity, treeManager.transform).transform;
			lastStalk = Instantiate (stalkPiece, new Vector3 (lastStalk.position.x + Random.Range (-0.1f, 0.1f), lastStalk.position.y + 0.1f), Quaternion.identity, treeManager.transform).transform;

		}




	}
		
}
