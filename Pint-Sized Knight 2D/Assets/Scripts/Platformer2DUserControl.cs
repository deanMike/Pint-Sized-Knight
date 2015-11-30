using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Platformer2DUserControl : MonoBehaviour {

    private VariableController variables;

    private PlatformerCharacter2D m_Character;

    private void Awake() {
        m_Character = GetComponent<PlatformerCharacter2D>();
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
    }


    private void Update() {

    }


    private void FixedUpdate() {
        // Read the inputs.
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        float v = CrossPlatformInputManager.GetAxis("Vertical");
        // Pass all parameters to the character control script.
        m_Character.Move(h, v);
        m_Character.Attack(variables.attack);
        m_Character.Defend(variables.defend);
    }
}
