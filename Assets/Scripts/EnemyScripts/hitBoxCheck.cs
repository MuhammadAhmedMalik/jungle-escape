using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitBoxCheck : MonoBehaviour
{
    private EnemyAI enemyAI;
    private PlayerCombat playerCombat;

    private void Awake()
    {
        enemyAI = GetComponentInParent<EnemyAI>();
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && enemyAI.attackMode && !enemyAI.cooling && !playerCombat.isDead)
        {
            playerCombat.TakeDamage(enemyAI.damage);
        }
    }
}
