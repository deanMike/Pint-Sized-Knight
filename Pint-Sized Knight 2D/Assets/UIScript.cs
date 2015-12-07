using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIScript : MonoBehaviour {

    private VariableController variables;
    public Slider healthSlider;
    public Image fill;

    // Use this for initialization
    void Start() {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
    }

    // Update is called once per frame
    void Update() {
        healthSlider.value = variables.currHealth;
    }
}
