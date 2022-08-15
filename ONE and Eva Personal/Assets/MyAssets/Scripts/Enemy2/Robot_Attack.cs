using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Attack : MonoBehaviour
{
    public int attackDamage = 20; 

    // the attack is happening as an animation event in state machine
    // this attack script just deals dmg, in "range" script is in robot_chase event script
    public void Attack()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().TakeDamage(attackDamage);
    }
}
