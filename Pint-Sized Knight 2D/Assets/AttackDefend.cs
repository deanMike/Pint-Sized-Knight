using UnityEngine;
using System.Collections;

public class AttackDefend : MonoBehaviour {
    private bool attacking;
    private bool defending;

    private float attackTimer = 0;
    private float attackEnd = 0.3f;

    private Collider2D attackTrigger;

    public VariableController variables;


    void Awake()
    {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        attackTrigger = GameObject.Find("AttackTrigger").GetComponent<Collider2D>();
        Debug.Log(GameObject.Find("AttackTrigger").GetComponent<Collider2D>() != null);

    }

    void Start() {
        attackTrigger.enabled = false;
        attacking = false;
    }

	
	// Update is called once per frame
	void Update () {
        Attack();
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
    public void Damage() {
    } 
}
