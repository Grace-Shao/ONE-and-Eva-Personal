using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGrapplingHook : MonoBehaviour
{
    // essentials
    private LineRenderer lineRenderer;
    private Transform player;
    //public DistanceJoint2D distanceJoint;
    private Rigidbody2D rb;

    // customizable
    [SerializeField] private int grappleSpeed;
    [SerializeField] private float attackRange = 2;
    // enumerator to make it more efficient than update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        /*if (Input.GetKeyDown(KeyCode.G))
        {*/
        Debug.Log("held G");
        Vector2 distToPlayer = player.position - transform.position;
        if (distToPlayer.magnitude >= attackRange)
        {
            lineRenderer.enabled = true;
            // FROM
            lineRenderer.SetPosition(1, transform.position);
            // TO
            lineRenderer.SetPosition(0, player.position);
            transform.position = Vector2.MoveTowards(transform.position, player.position, 5 * Time.deltaTime);
        } else
        {
            if (lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }
            
        /*} else if (Input.GetKeyUp(KeyCode.G))
        {
            //distanceJoint.enabled = false;
            lineRenderer.enabled = false;
        }*/

    }
    /*public IEnumerator GrappleCoroutine()
    {
        
    }*/
    // make boss face player (calculate where player is)
    // maybe attach to player first
    // (later) find closest wall, grappling hook attaches on there
}
