using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScript : MonoBehaviour {

    private VariableController variables;

    public string message;
    public string winMessage;
    public Text text;
    public float pause;
    public GameObject panel;
    private string controls;

    private bool[] steps;

    private bool displayAll;


    // Use this for initialization
    void Start() {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        if (Application.loadedLevel == 1) {
            text.text = "";
            StartCoroutine(TypeText());
            controls = "Attack - Space \nDefend - Shift \nMove using either the WASD keys or the Arrow keys.";
            steps = new bool[4];
            for (int i = 0; i < steps.Length; i++) {
                steps[i] = false;
            }
            steps[0] = true;
        }
    }

    // Update is called once per frame
    IEnumerator TypeText() {
        foreach (char letter in message.ToCharArray()) {
            text.text += letter;
            yield return new WaitForSeconds(pause);
        }
    }

    void Update() {
        if (Application.loadedLevel == 1) {
            if (displayAll) {
                StopAllCoroutines();
                text.text = message;
            }
            if (Input.GetKeyDown(KeyCode.Space) && steps[0]) {
                displayAll = true;
                steps[0] = false;
                steps[1] = true;
            }
            if (Input.GetKeyDown(KeyCode.Space) && text.text == message) {
                panel.SetActive(false);
            }
        }
        if (variables.win) {
            variables.win = false;
            text.text = "";
            StartCoroutine(TypeEnd());
        }
    }


    IEnumerator TypeControls() {
        foreach (char letter in controls.ToCharArray()) {
            text.text += letter;
            yield return new WaitForSeconds(pause);
        }
    }
    IEnumerator TypeEnd() {
        foreach (char letter in winMessage.ToCharArray()) {
            text.text += letter;
            yield return new WaitForSeconds(pause);
        }
    }
}
