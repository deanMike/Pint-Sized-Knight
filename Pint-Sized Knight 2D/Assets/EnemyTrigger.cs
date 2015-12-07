using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {

    public int damage = 5;

    void OnTriggerEnter2D(Collider2D col) {
        if (!col.isTrigger && col.CompareTag("Player")) {
            Debug.Log("OWWW!");
            col.SendMessage("Damage", damage);
        }
    }
}
