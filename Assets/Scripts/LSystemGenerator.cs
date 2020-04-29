using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemGenerator : MonoBehaviour
{
    [SerializeField] private int iterations = 3;
    [SerializeField] private float angle = 25f;
    [SerializeField] private float width = 0.5f;
    [SerializeField] private float length = 1;
    [SerializeField] private GameObject branchPrefab;

    private string axiom = "F";
    private string currentString;
    private Dictionary <char, string> rules = new Dictionary <char, string> ();
    private Stack<TransformInfo> transformStack = new Stack<TransformInfo> ();
    private Vector3 initialPos;

    private void Start() {
        // rules.Add ('A', "AB");
        // rules.Add ('B', "A");

        rules.Add ('F', "FF+[+F-F-F]-[-F+F+F]");

        Generate ();
    }

    private void Update() {
        if (Input.GetKeyDown (KeyCode.Space)) {
            Generate ();
        }
    }

    private void Generate () {
        transform.position = Vector3.zero;
        
        currentString = axiom;
        string newString = "";

        for (int x = 0; x < iterations; x++)
        {   
            char[] stringCharacters = currentString.ToCharArray();

            for (int i = 0; i < stringCharacters.Length; i++)
            {
                char currentCharacter = stringCharacters[i];

                newString += rules.ContainsKey (currentCharacter) ? rules[currentCharacter] : currentCharacter.ToString();
            }

            currentString = newString;
            newString = "";
        }

        for (int j = 0; j < currentString.Length; j++) {
            char currentCharacter = currentString[j];

            switch (currentCharacter) {
                case 'F' :
                    initialPos = transform.position;
                    transform.Translate (Vector3.up * length);

                    // var branchGO = Instantiate (branchPrefab, transform.position, transform.rotation, transform);
                    
                    // LineRenderer lineRenderer = branchGO.GetComponent <LineRenderer> ();
                    // lineRenderer.SetPosition (0, initialPos);
                    // lineRenderer.SetPosition (1, transform.position);
                    // lineRenderer.startWidth = width;
                    // lineRenderer.endWidth = width;

                    Debug.DrawLine (initialPos, transform.position, Color.white, 10, false);
                    break;
                case '+' :
                    transform.Rotate (Vector3.forward * angle);
                    break;
                case '-' :
                    transform.Rotate (Vector3.forward * -angle);
                    break;
                case '[' :
                    TransformInfo pushTI = new TransformInfo (transform.position, transform.rotation);
                    transformStack.Push (pushTI);
                    break;
                case ']' :
                    TransformInfo popTI = transformStack.Pop ();
                    transform.position = popTI.position;
                    transform.rotation = popTI.rotation;
                    break;
            }
        }
    }
}

public struct TransformInfo {
    public Vector3 position;
    public Quaternion rotation;
    public TransformInfo (Vector3 pos, Quaternion rot) {
        position = pos;
        rotation = rot;
    }
}
