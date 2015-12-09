using UnityEngine;
using System.Collections;

public class OverlayScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Appear();
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void Appear() {
        Color tempcolor = gameObject.GetComponent<Renderer>().material.color;
        tempcolor.a = Mathf.MoveTowards(0, 255, Time.deltaTime);
        gameObject.GetComponent<Renderer>().material.color = tempcolor;
    }
}
