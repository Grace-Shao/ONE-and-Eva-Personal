using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Patrol : StateMachineBehaviour
{
    public float speed = 2;
    public float rayDistance;


    private bool movingRight = true;
    public Transform groundDetection;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //ref animator.transform to get robot's transform
        animator.transform.Translate(Vector2.right * speed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(animator.transform.position, Vector2.down, rayDistance);
        Debug.DrawRay(animator.transform.position, Vector2.down * rayDistance, Color.red, 1);
        // if robot walks off ground
        if(groundInfo.collider == false)
        {
            Debug.Log("Not on ground");
            if(movingRight == true)
            {
                // turn the other way
                animator.transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            } else
            {
                // if moving left, turn right
                animator.transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
