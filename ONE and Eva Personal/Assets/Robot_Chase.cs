using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Chase : StateMachineBehaviour
{
    public float speed = 50f;
    public float attackRange = 1f;

    Transform player;
    Rigidbody2D rb;
    Boss robot; // just inherit from the boss class for now since it has the lookAt function

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        robot = animator.GetComponent<Boss>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        robot.LookAtPlayer();
        Vector2 target = new Vector2(player.position.x, rb.position.y);    // y is boss position bc we don't want the boss to move down
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);  // moves to target pos
        //Debug.Log(newPos);
        rb.MovePosition(newPos);

        // if in attack range 
        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            // attack
            animator.SetTrigger("attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // when attack ends, reset the attack bool in animator
        animator.ResetTrigger("attack");
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