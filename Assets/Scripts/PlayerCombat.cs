using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int maxHealth = 100;
    int currentHealth;
    public HealthBar healthBar;
    public bool isDead;

    public float attackRate =2.0f;
    private float nextAttackTime = 0f;
    public float attackRange = 0.5f;
    public int attackDamage = 40;

    public AudioSource audioSource;
    AudioClip swordSwish;

    private void Start()
    {
        swordSwish = Resources.Load<AudioClip>("Audio/Sword_Swish");
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }
    void Attack()
    {
        if (isDead)
            return;

        // Play attack sound
        audioSource.PlayOneShot(swordSwish);

        //Play an Attack Animation
        animator.SetTrigger("Attack");

        //Detect Enemies in Range of Attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.GetComponent<Collider2D>().tag == "Enemy")
            {
                Debug.Log("We hit enemy!");
                enemy.GetComponentInParent<EnemyCombat>().TakeDamage(attackDamage);
            }
            
        }
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;
        Debug.Log("Player Takes damage of " + damage);

        // Play hurt animation
        animator.SetTrigger("Hurt");

        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player Died!");

        //Die Animation
        animator.SetBool("isDead", true);

        isDead = true;
    }

    void OnDrawGizmosSelected() 
    {
        if(attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
