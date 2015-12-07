using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    private GameObject character;
    private float speed;
    public int maxHealth = 30;
    private int currHealth;
    private float timeFlash;
    public Color orig;
    public Color flash;

    private Vector3 origPos;
    private Collider2D enemyAttackTrigger;

    private bool enemyAttacking;
    private float enemyAttackTimer;
    private float enemyAttackEnd = 0.1f;
    private bool enemyAttack;
    public bool test;

    // Use this for initialization
    void Awake() {
        origPos = GetComponent<Transform>().position;
        character = GameObject.Find("Character");
        enemyAttackTrigger = GetComponentsInChildren<Collider2D>()[1];
    }
    void Start() {
        enemyAttackTrigger.enabled = false;
        speed = 2;
        currHealth = maxHealth;
        timeFlash = 0;
    }

    // Update is called once per frame
    void Update() {
        if (!(Mathf.Abs(transform.position.x - character.transform.position.x) <= 1.5f && Mathf.Abs(transform.position.y - character.transform.position.y) <= 2.0f)) {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, character.transform.position, speed * Time.deltaTime);
        } else {
            Debug.Log("Attack!");
            Invoke("EnemyAttack", 1.0f);
        }
        if (currHealth <= 0) {
            Explode();
            //transform.position = origPos;
            currHealth = maxHealth;
            gameObject.GetComponent<Renderer>().material.color = orig;
            Invoke("DestroyEnemy", 0.5f);
        }
    }

    void Damage(int damage) {
        currHealth -= damage;
        StartCoroutine(FlashColor(flash, 0.2f));
    }

    IEnumerator FlashColor(Color col, float wait) {
        Debug.Log(0);
        gameObject.GetComponent<Renderer>().material.color = col;
        yield return new WaitForSeconds(wait);
        gameObject.GetComponent<Renderer>().material.color = orig;
        Debug.Log(0.5f);
    }

    private void Explode() {
        float multiplier = 1;


        var systems = GetComponentsInChildren<ParticleSystem>();

        foreach (ParticleSystem system in systems) {
            system.startSize *= multiplier;
            system.startSpeed *= multiplier;
            system.startLifetime *= Mathf.Lerp(multiplier, 1, 0.5f);
            system.Clear();
            system.Play();
        }
    }

    private void DestroyEnemy() {
        Destroy(gameObject);
    }

    private void EnemyAttack() {
        if (!enemyAttacking) {
            enemyAttacking = true;
            enemyAttackTimer = enemyAttackEnd;
            StartCoroutine(FlashColor(Color.yellow, 0.2f));
            enemyAttackTrigger.enabled = true;
        }

        if (enemyAttacking) {
            if (enemyAttackTimer > 0) {
                enemyAttackTimer -= Time.deltaTime;
            } else {
                enemyAttacking = false;
                enemyAttackTrigger.enabled = false;
            }
        }
    }
}
