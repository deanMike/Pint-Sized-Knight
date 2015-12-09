using UnityEngine;
using System.Collections;

public class InstructionText : MonoBehaviour {

    private VariableController variables;
	// Use this for initialization
	void Start () {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (variables.gameStart) {
            Invoke("DestroyText", 3);
        }
	}

    void DestroyText() {
        Destroy(gameObject);
    }
}
