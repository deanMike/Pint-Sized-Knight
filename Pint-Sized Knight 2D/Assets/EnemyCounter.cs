using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCounter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    GetComponent<Text>().text = "Wisps Remaining: " + GameObject.FindGameObjectsWithTag("Enemy").Length;
	}
}
