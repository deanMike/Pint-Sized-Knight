using UnityEngine;
using System.Collections;

public class VariableController : MonoBehaviour {

    public float playerHealth;      // Player's starting health.
    public int numHitsKill;         // Number of hits required to kill the weakest monster.
    public float playerSpeed;       // Maximum player movement speed.
    public float monsterSpeed;      // Minimum monster movement speed.
    public float[] volume;          // Array of volume values.
    public float monstersOnScreen;  // Maximum number of monsters on screen.
    //Audio Related Variables
    public int[] charAttackSounds;
    public int[] defendsounds;
    public int[] charDamageSounds;
    public int[] enemyAttackSounds;
    public int[] enemyDamageSounds;
    public int[] enemyRoars;
    public int[] lionRoars;
    public bool attack;
    public bool defend;

}
