using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int enragedHealth = 50;
    public int currentHealth;

    public HealthBar healthBar;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        Debug.Log("Boss takes dmg");
        animator.SetTrigger("isHit");
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if(currentHealth <= 200)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // die animation

        // disable the enemy
        Destroy(gameObject);

    }
}
