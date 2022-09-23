using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    public HealthBar healthBar;

    private bool isDead;

    AudioClip hurtAudio;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        hurtAudio = Resources.Load<AudioClip>("Audio/Enemy_Die");
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
            return;

        currentHealth -= damage;
        Debug.Log("Takes damage of " + damage);
        healthBar.SetHealth(currentHealth);
        
        audioSource.PlayOneShot(hurtAudio);
        
        // Play hurt animation
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            
            Die();
        }
    }
    void Die()
    {
        isDead = true;
        Debug.Log("Enemy Died!");

        //Die Animation
        animator.SetBool("isDead",true);

        //Diasable Enemy
        
        this.enabled = false;
    }
}
