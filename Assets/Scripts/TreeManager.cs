using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {

	public GenerateTree treeGenerator;

	public float Height { get; private set;} 

	void Start ()
	{
		Height = Random.Range (1f, 5f);
	}

	void Update () {
		
	}

}
