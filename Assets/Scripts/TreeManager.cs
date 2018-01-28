using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {

	public float Height;
	public List <GameObject> treeGenList = new List <GameObject> ();
	public GameObject treeGenPrefab;

	//bool branch;

	void Start ()
	{
		Height = Random.Range (1f, 10f);
		foreach (GameObject a in GameObject.FindGameObjectsWithTag ("TreeGenerators"))  {
			treeGenList.Add (a);
		}
	}

	void Update ()
	{

		//if (treeGenList [0].transform.position.y >= Height && !branch) {
		if (Input.GetKeyDown (KeyCode.Space) && treeGenList[0].GetComponent <GenerateTree>().isGrowing) {
			CreateBranch ();
			//branch = true;
			foreach (GameObject a in treeGenList) {
				a.GetComponent<GenerateTree> ().isLeaves = true;
			}
		}
	}

	void CreateBranch ()
	{
		treeGenList.Add (Instantiate (treeGenPrefab, treeGenList [0].transform.position, Quaternion.identity));
	}
}
