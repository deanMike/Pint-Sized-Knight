﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    private GameObject character;
    private float speed;
    public int maxHealth;
    private int currHealth;
    private float timeFlash;
    public Color orig;
    public Color flash;

    public AudioClip[] sounds;
    private AudioSource aSource;

    private VariableController variables;

    private Vector3 origPos;
    private Collider2D enemyAttackTrigger;

    private bool enemyAttacking;
    private float enemyAttackTimer;
    private float enemyAttackEnd = 0.3f;
    private bool enemyAttack;
    public bool test;

    private System.Random rand;

    // Use this for initialization
    void Awake() {
        origPos = GetComponent<Transform>().position;
        enemyAttackTrigger = GetComponentsInChildren<Collider2D>()[1];
        aSource = GetComponent<AudioSource>();
        
    }
    void Start() {
        rand = new System.Random();
        variables = GameObject.Find("Variables").GetComponent<VariableController>();
        character = GameObject.Find("Character");
        enemyAttackTrigger.enabled = false;
        speed = 2;
        if (Application.loadedLevel == 1) {
            currHealth = maxHealth;
        } else if (Application.loadedLevel == 2) {
            currHealth = maxHealth + 5;
        } else {
            currHealth = maxHealth + 10;
        }
        timeFlash = 0;
        InvokeRepeating("EnemyAttack", 1.0f, Random.Range(1.0f, 5.0f));
    }

    // Update is called once per frame
    void Update() {
        if (variables.gameStart && !(Mathf.Abs(transform.position.x - character.transform.position.x) <= 1.5f && Mathf.Abs(transform.position.y - character.transform.position.y) <= 2.0f)) {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, character.transform.position, speed * Time.deltaTime);
        } 
        if (currHealth <= 0) {
            aSource.clip = sounds[0];
            aSource.Play();
            Explode();
            //transform.position = origPos;
            Invoke("DestroyEnemy", 0.5f);
        }
    }

    void Damage(int damage) {
        currHealth -= damage;
        var systems = GetComponentsInChildren<ParticleSystem>();
        aSource.clip = sounds[rand.Next(4, 7)];
        aSource.Play();
        foreach (ParticleSystem system in systems) {
            system.startColor = Color.red;
            system.Clear();

        }
    }

    IEnumerator FlashColor(Color col, float wait) {
        gameObject.GetComponent<Renderer>().material.color = col;
        yield return new WaitForSeconds(wait);
        gameObject.GetComponent<Renderer>().material.color = orig;
    }

    private void Explode() {
        float multiplier = 1.2f;


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
        if (variables.gameStart && (Mathf.Abs(transform.position.x - character.transform.position.x) <= 1.5f && Mathf.Abs(transform.position.y - character.transform.position.y) <= 2.0f)) {
            if (!enemyAttacking) {
                var systems = GetComponentsInChildren<ParticleSystem>();

                foreach (ParticleSystem system in systems) {
                    system.startColor = Color.yellow;
                    system.Clear();

                }
                aSource.clip = sounds[rand.Next(1, 4)];
                aSource.Play();
                enemyAttacking = true;
                enemyAttackTimer = enemyAttackEnd;
                StartCoroutine(FlashColor(Color.yellow, 0.2f));
                enemyAttackTrigger.enabled = true;
                Invoke("EnemyAttackEnd", 0.1f);
                foreach (ParticleSystem system in systems) {
                    system.startColor = Color.white;
                    system.Clear();

                }
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
    private void EnemyAttackEnd() {
        enemyAttackTrigger.enabled = false;
        enemyAttacking = false;
    }
}
