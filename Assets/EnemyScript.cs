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

    public int damageAmt;

    private float attackTimer;
    private float attackEnd = 0.3f;

    private Collider2D attackTrigger;
    private bool attacking;

    private Vector3 origPos;

    private VariableController variables;

    // Use this for initialization
    void Start() {
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        origPos = GetComponent<Transform>().position;
        character = GameObject.Find("Character");
        speed = 2;
        currHealth = maxHealth;
        timeFlash = 0;
        attackTrigger = GameObject.Find("EnemyAttackTrigger").GetComponent<Collider2D>();
        attackTrigger.enabled = false;
        attacking = false;
    }

    // Update is called once per frame
    void Update() {
        if (!(Mathf.Abs(transform.position.x - character.transform.position.x) <= 1 && Mathf.Abs(transform.position.y - character.transform.position.y) <= 1.5f)) {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, character.transform.position, speed * Time.deltaTime);
        }
        if (currHealth <= 0) {
            Explode();
            //transform.position = origPos;
            currHealth = maxHealth;
            gameObject.GetComponent<Renderer>().material.color = orig;
            Invoke("DestroyEnemy", 0.5f);
        }

        Invoke("EnemyAttack", 2);
    }

    void Damage(int damage) {
        currHealth -= damage;
        StartCoroutine(FlashColor());
        Debug.Log(gameObject.GetComponent<Renderer>().material.color);
        gameObject.GetComponent<Renderer>().material.color = flash;
    }

    IEnumerator FlashColor() {
        Debug.Log(0);
        yield return new WaitForSeconds(0.2f);
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

    public void EnemyAttack() {
        if (variables.defend) {
            Damage(1);
        }
        if (!attacking) {
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
            }
        }
    }
}
