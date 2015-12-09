using UnityEngine;
using System.Collections;

public class AttackDefend : MonoBehaviour {
    private bool attacking;
    private bool defending;

    private float attackTimer = 0;
    private float attackEnd = 1.0f;

    private Collider2D attackTrigger;
    private Collider2D playerCollider;

    private VariableController variables;

    private Color orig;

    public AudioClip[] sounds;
    private AudioSource aSource;

    private System.Random rand;




    void Awake()
    {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        attackTrigger = GameObject.Find("AttackTrigger").GetComponent<Collider2D>();
        orig = GetComponent<SpriteRenderer>().color;
        playerCollider = GetComponent<Collider2D>();
        aSource = GetComponent<AudioSource>();
    }

    void Start() {
        attackTrigger.enabled = false;
        attacking = false;
        variables.currHealth = variables.playerHealth;
        rand = new System.Random();
    }

	
	// Update is called once per frame
	void Update () {
        Attack();
        //Reload current level if HP reaches 0.
        if (variables.currHealth <= 0) {
            variables.currHealth = variables.playerHealth;
            Application.LoadLevel(Application.loadedLevelName);
            if (Application.loadedLevel == 2) {
                transform.position = new Vector2(-4.92f, 20.04f);
            }
            if (Application.loadedLevel == 1) {
                Destroy(gameObject);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (!col.isTrigger && col.CompareTag("Lion")) {
            Debug.Log("Win!!");
            variables.win = true;
        }
    }

    public void Attack() {
        if (variables.attack && !attacking) {
            aSource.clip = sounds[rand.Next(0, 6)];
            aSource.Play();
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
            aSource.clip = sounds[12];
            dmg = 1;
        } else {
            aSource.clip = sounds[rand.Next(6, 12)];

        }
        aSource.Play();
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
