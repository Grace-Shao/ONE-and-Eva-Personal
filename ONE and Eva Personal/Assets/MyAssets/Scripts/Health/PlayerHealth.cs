using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;

    public HealthBar healthBar;

    public LevelLoader levelLoader;

    // Start is called before the first frame update
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
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //SceneManager.LoadScene("LoseScreen");
        // die animation
        animator.SetBool("IsDead", true);

        // after death animation is done (nornalized time = 1 means animation done)
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
        {
            // disable the player
            Debug.Log("Player ded");

            // load next scene
            levelLoader.LoadLoseScreen();
            //gameObject.SetActive(false);
        }
        // Destroy(gameObject);

    }
}
