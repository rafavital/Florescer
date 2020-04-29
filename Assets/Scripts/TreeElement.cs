using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (LineRenderer))]
public class TreeElement : MonoBehaviour
{
    private LineRenderer lr;
    private void Awake() {
        lr = GetComponent <LineRenderer> ();
    }

}
