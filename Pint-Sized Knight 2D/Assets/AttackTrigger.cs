using UnityEngine;
using System.Collections;

public class AttackTrigger : MonoBehaviour {

    public int damage = 15;
	
    void OnTriggerEnter2D(Collider2D col)
    {
        if(!col.isTrigger && col.CompareTag("Enemy"))
        {
            Debug.Log("OWWW!");
            col.SendMessage("Damage", damage);
        }
    }
}
