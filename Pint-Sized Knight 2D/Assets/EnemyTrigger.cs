using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour {

    public int damage = 10;

    void OnTriggerEnter2D(Collider2D col) {
        if (!col.isTrigger && col.CompareTag("Player")) {
            col.SendMessage("Damage", damage);
        }
    }
}
