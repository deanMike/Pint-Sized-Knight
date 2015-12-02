using UnityEngine;
using System.Collections;

public class InstructionText : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("DestroyText", 3);
	}

    void DestroyText() {
        Destroy(gameObject);
    }
}
