using UnityEngine;
using System.Collections;

public class FenceScript : MonoBehaviour {
    public GameObject one;
    public GameObject two;
    public GameObject three;

    public VariableController variables;

    public float openTime;
    private bool open;
    // Use this for initialization
    void Start() {
        one.SetActive(false);
        two.SetActive(false);
    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            openGate();
        }
    }
    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            openGate();
            variables.gameStart = true;
        }
    }
    private void openGate() {
        if (!open) {
            Invoke("Three", 0.2f);
            Invoke("Two", 0.2f);
            Invoke("Two", 0.4f);
            Invoke("One", 0.4f);
            open = true;

        } else {
            Invoke("One", 0.2f);
            Invoke("Two", 0.2f);
            Invoke("Two", 0.4f);
            Invoke("Three", 0.4f);
            open = false;
        }


        //Invoke("Three", 0.3f);
        //Invoke("Three", 0.3f);
    }
    private void closeGate() {

    }
    private void One() {
        if (one.activeInHierarchy) {
            one.SetActive(false);
        } else {
            one.SetActive(true);
        }
    }
    private void Two() {
        if (two.activeInHierarchy) {
            two.SetActive(false);
        } else {
            two.SetActive(true);
        }
    }
    private void Three() {
        if (three.activeInHierarchy) {
            three.SetActive(false);
        } else {
            three.SetActive(true);
        }
    }
}
