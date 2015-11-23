using UnityEngine;
using System.Collections;

public class AttackDefend : MonoBehaviour {
    private bool attacking;
    private bool defending;

    private float attackTimer = 0;
    private float attackEnd = 0.3f;

    private Collider2D attackTrigger;


    void Awake()
    {
        attackTrigger = GameObject.Find("AttackTrigger").GetComponent<Collider2D>();
        attackTrigger.enabled = false;
    }

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Space) && !attacking)
        {
            attacking = true;
            attackTimer = attackEnd;

            attackTrigger.enabled = true;
        }

        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            } else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }
    }
}
