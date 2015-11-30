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

	// Use this for initialization
	void Start () {
        origPos = GetComponent<Transform>().position;
        character = GameObject.Find("Character");
        speed = 2;
        currHealth = maxHealth;
        timeFlash = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!(Mathf.Abs(transform.position.x - character.transform.position.x) <= 1 && Mathf.Abs(transform.position.y - character.transform.position.y) <= 1.5f)) {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, character.transform.position, speed * Time.deltaTime);
        }
        if(currHealth <= 0)
        {
            transform.position = origPos;
            currHealth = maxHealth;
            gameObject.GetComponent<Renderer>().material.color = orig;
            //Destroy(gameObject);
        }
    }

    void Damage(int damage)
    {
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
}
