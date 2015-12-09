using UnityEngine;
using System.Collections;

public class LionRoar : MonoBehaviour {
    private VariableController variables;

	// Use this for initialization
	void Start () {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (variables.win) {
            GetComponent<AudioSource>().Play();
        }
	}
}
