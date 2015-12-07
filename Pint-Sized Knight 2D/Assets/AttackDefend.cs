using UnityEngine;
using System.Collections;

public class AttackDefend : MonoBehaviour {
    private bool attacking;
    private bool defending;

    private float attackTimer = 0;
    private float attackEnd = 0.3f;

    private Collider2D attackTrigger;

    private VariableController variables;

    private Color orig;


    void Awake()
    {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        attackTrigger = GameObject.Find("AttackTrigger").GetComponent<Collider2D>();
        Debug.Log(GameObject.Find("AttackTrigger").GetComponent<Collider2D>() != null);
        orig = GetComponent<SpriteRenderer>().color;
    }

    void Start() {
        attackTrigger.enabled = false;
        attacking = false;
        variables.currHealth = variables.playerHealth;
    }

	
	// Update is called once per frame
	void Update () {
        Attack();
        //Reload current level if HP reaches 0.
        if (variables.currHealth <= 0) {
            variables.currHealth = variables.playerHealth;
            Application.LoadLevel(Application.loadedLevelName);
        }
    }

    public void Attack() {
        if (variables.attack && !attacking) {
            attacking = true;
            attackTimer = attackEnd;

            attackTrigger.enabled = true;
        }
        
        if (attacking) {
            if (attackTimer > 0) {
                attackTimer -= Time.deltaTime;
            } else {
                attacking = false;
                attackTrigger.enabled = false;
                variables.attack = false;
            }
        }
    }
    public void Damage(int dmg) {
        if (variables.defend) {
            dmg = 1;
        }
        StartCoroutine(FlashColor(Color.red, 0.2f));
        variables.currHealth -= dmg;
        Debug.Log("Health: " + variables.currHealth);

    }

    IEnumerator FlashColor(Color col, float wait) {
        Debug.Log(0);
        gameObject.GetComponent<Renderer>().material.color = col;
        yield return new WaitForSeconds(wait);
        gameObject.GetComponent<Renderer>().material.color = orig;
        Debug.Log(0.5f);
    }
}
