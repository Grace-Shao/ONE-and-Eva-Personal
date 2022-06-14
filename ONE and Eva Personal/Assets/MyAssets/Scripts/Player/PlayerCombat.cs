using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttack = 0f;
    void Update()
    {
        if (Time.time >= nextAttack)
        {
            if (Input.GetButtonDown("Attack"))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
            /* incoporate special attack button later
            if (Input.GetButtonDown("Strong Attack"))
            {
                Attack();
                nextAttack = Time.time + 1f / attackRate;
            }
            */
        }

    }
    void Attack()
    {
        // Play an attack animation
        animator.SetTrigger("Attack");

        // Play audio
        //FindObjectOfType<AudioManager>().Play("PlayerAttack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            //Debug.Log("ONE Attack");
            
            Debug.Log("ONE hit " + enemy.name);
            // if boss, deal dmg to boss
            if (enemy.GetComponent<BossHealth>())
            {
                Debug.Log("ONE Attack");
                enemy.GetComponent<BossHealth>().TakeDamage(attackDamage);
            }
            // if normal enemmy, deal dmg to norm enemy
            if (enemy.GetComponent<Robot_Health>())
            {
                Debug.Log("ONE Attack");
                enemy.GetComponent<Robot_Health>().TakeDamage(attackDamage);
            }

        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
