using UnityEngine;
using System.Collections;

public class EnemyAttackTrigger : MonoBehaviour {

    public int damage = 5;

    void OnTriggerEnter2D(Collider2D col) {
        if (!col.isTrigger && col.CompareTag("Enemy")) {
            Debug.Log("OWWW!");
            col.SendMessage("Damage", damage);
        }
    }
}

