using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    private GameObject character;
    private float speed;
    public int maxHealth = 30;
    private int currHealth;

	// Use this for initialization
	void Start () {
        character = GameObject.Find("Character");
        speed = 2;
        currHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, character.transform.position, speed * Time.deltaTime);
        if(currHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log(currHealth);
	}

    void Damage(int damage)
    {
        currHealth -= damage;

    }
}
