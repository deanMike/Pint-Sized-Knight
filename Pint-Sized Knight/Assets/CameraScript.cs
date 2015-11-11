using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        pan(Camera.main.WorldToViewportPoint(player.transform.position));
        Debug.Log(gameObject.transform.position);
	}


    public void pan(Vector3 charPos) {
        if (charPos.x >= 1) {
            gameObject.transform.Translate(new Vector3(12.29f, 0, 0), Space.Self);
        }
        if (charPos.x <= 0) {
            gameObject.transform.Translate(new Vector3(-12.29f, 0, 0), Space.Self);
        }
        if (charPos.y >= 1) {
            gameObject.transform.Translate(new Vector3(0, 0, 12.81f), Space.Self);
        }
        if (charPos.y <= 0) {
            gameObject.transform.Translate(new Vector3(0, 0, -12.81f), Space.Self);
        }
    }
}
