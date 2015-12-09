using UnityEngine;
using System.Collections;

public class LionScript : MonoBehaviour {

    private VariableController variables;
    private AudioSource lionSound;
    public GameObject panel;
    
    void Start() {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        lionSound = GetComponent<AudioSource>();
        //panel = GameObject.Find("Panel");
    }
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D col) {
        lionSound.Play();
        variables.win = true;
        variables.gameStart = false;
        Destroy(gameObject);
    }
}
