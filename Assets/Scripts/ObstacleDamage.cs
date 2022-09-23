using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDamage : MonoBehaviour
{
    public int damage;
    private PlayerCombat playerCombat;

    private void Awake()
    {
        playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !playerCombat.isDead)
        {
            playerCombat.TakeDamage(damage);
            Debug.Log("Obstacle Damage = " + damage);
        }
    }
}
