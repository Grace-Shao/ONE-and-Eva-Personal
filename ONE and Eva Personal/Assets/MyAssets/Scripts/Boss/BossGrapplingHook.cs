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
    private int enemyLayer = 7;

    // customizable
    [SerializeField] private int grappleSpeed;
    [SerializeField] private float attackRange = 2;
    [SerializeField] private float chainRange = 10;
    // enumerator to make it more efficient than update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // if the boss can "see" the player and nothing else is blocking it's direction
        Vector2 distToPlayer = player.position - transform.position;
        RaycastHit2D detectPlayerRay = Physics2D.Raycast(transform.position, distToPlayer.normalized, chainRange, ~(1 << enemyLayer));
        Debug.DrawRay(transform.position, distToPlayer.normalized * chainRange, Color.red);
        Debug.Log("boss chain detects " + detectPlayerRay.collider.tag);
        if (detectPlayerRay.collider.CompareTag("Player"))
        {
            Debug.Log("boss chain detects " + detectPlayerRay.collider.tag);
            if (distToPlayer.magnitude >= attackRange)
            {
                lineRenderer.enabled = true;
                // FROM
                lineRenderer.SetPosition(1, transform.position);
                // TO
                lineRenderer.SetPosition(0, player.position);
                transform.position = Vector2.MoveTowards(transform.position, player.position, 5 * Time.deltaTime);
            }
            else
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
        }        
    }

    /*private RaycastHit2D CheckRayHitPlayer()
    {

    }*/
    /*public IEnumerator GrappleCoroutine()
    {
        
    }*/
    // make boss face player (calculate where player is)
    // maybe attach to player first
    // (later) find closest wall, grappling hook attaches on there
}
