using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Platformer2DUserControl : MonoBehaviour {

    public VariableController variables;
    public Sprite winner;
    private bool pose;
    private PlatformerCharacter2D m_Character;

    private void Awake() {
        m_Character = GetComponent<PlatformerCharacter2D>();
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        DontDestroyOnLoad(gameObject);
        pose = false;
    }


    private void Update() {
        if (variables.win || pose) {
            pose = true;
            gameObject.GetComponent<SpriteRenderer>().sprite = winner;
        }
    }


    private void FixedUpdate() {
        // Read the inputs.
        float h, v;
        if (GameObject.Find("Message") == null) {
            h = CrossPlatformInputManager.GetAxis("Horizontal");
            v = CrossPlatformInputManager.GetAxis("Vertical");
        } else {
            h = 0;
            v = 0;
        }
        // Pass all parameters to the character control script.
        m_Character.Move(h, v);
        m_Character.Attack(variables.attack);
        m_Character.Defend(variables.defend);
    }
}
