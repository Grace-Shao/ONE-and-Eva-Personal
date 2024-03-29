using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Boss_Run : StateMachineBehaviour
{
    public float speed = 50f;
    public float attackRange = 1f;

    Transform player;
    Rigidbody2D rb;
    Boss boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target;
        // if boss is grounded, then y is boss position bc we don't want the boss to move down
        if (animator.GetBool("isGrounded")){
            target = new Vector2(player.position.x, rb.position.y);
        // else if boss is in air, it will follow the player in air
        } else
        {
            target = new Vector2(player.position.x, player.position.y);
        }
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);  // moves to target pos

        //Debug.Log(newPos);
        rb.MovePosition(newPos);

        // if in attack range 
        if(Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            // attack
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // when attack ends, reset the attack bool in animator
        animator.ResetTrigger("Attack");
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
