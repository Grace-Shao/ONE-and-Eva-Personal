using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Grapple : StateMachineBehaviour
{
    // essentials
    private LineRenderer lineRenderer;
    private Transform player;
    private Rigidbody2D rb;
    private int enemyLayer = 7;

    // customizable
    [SerializeField] private float attackRange = 2;
    [SerializeField] private float chainRange = 10;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lineRenderer = animator.GetComponent<LineRenderer>();
        rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector2 distToPlayer = player.position - animator.transform.position;
        RaycastHit2D detectPlayerRay = Physics2D.Raycast(animator.transform.position, distToPlayer.normalized, chainRange, ~(1 << enemyLayer));
        // if the boss can "see" the player and nothing else is blocking it's direction
        Debug.DrawRay(animator.transform.position, distToPlayer.normalized * chainRange, Color.red);
        if (detectPlayerRay.collider.CompareTag("Player"))
        {
            Debug.Log("boss chain detects " + detectPlayerRay.collider.tag);
            if (distToPlayer.magnitude >= attackRange)
            {
                lineRenderer.enabled = true;
                // Maybe will implement LineDraw in the future
                //StartCoroutine(LineDraw(transform.position, player.position));
                // FROM
                lineRenderer.SetPosition(1, animator.transform.position);
                // TO
                lineRenderer.SetPosition(0, player.position);
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.position, 5 * Time.deltaTime);
            }
            else
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
        }
        else
        {
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lineRenderer.enabled = false;
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
//https://forum.unity.com/threads/how-can-i-animate-draw-a-line-renderer-over-a-given-period-of-time.514664/ 
    /*IEnumerator LineDraw(Vector3 transform, Vector3 player)
    {
        float t = 0;
        float time = 2;
        Vector3 orig = transform;
        Vector3 orig2 = player;
        // FROM
        lineRenderer.SetPosition(1, orig);
        Vector3 newpos;
        for (; t < time; t += Time.deltaTime)
        {
            // lerp = gradually find a pt btw 2 pts
            newpos = Vector3.Lerp(orig, orig2, t / time);
            lineRenderer.SetPosition(0, newpos);
            yield return null;
        }
        lineRenderer.SetPosition(0, orig2);
        Debug.Log(transform + "1st" + lineRenderer.GetPosition(0) + "2nd" + player + " " + lineRenderer.GetPosition(1));

    }*/
    // make boss face player (calculate where player is)
    // maybe attach to player first
    // (later) find closest wall, grappling hook attaches on there
