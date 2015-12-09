using System.Collections;
using UnityEngine;

public class VariableController : MonoBehaviour {

    public int playerHealth;      // Player's starting health.
    public int currHealth;

    public int numHitsKill;         // Number of hits required to kill the weakest monster.
    public float playerSpeed;       // Maximum player movement speed.
    public float monsterSpeed;      // Minimum monster movement speed.
    public float[] volume;          // Array of volume values.
    public float monstersOnScreen;  // Maximum number of monsters on screen.
                                    //Audio Related Variables
    public bool gameStart;

    public bool attack;
    public bool defend;

    public bool win = false;

    public void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            attack = true;
        }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
            defend = true;
        } else {
            defend = false;
        }
    }
}