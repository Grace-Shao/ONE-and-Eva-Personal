using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossGrapplingHook : MonoBehaviour
{
    public Camera mainCamera;
    public LineRenderer lineRenderer;
    public DistanceJoint2D distanceJoint;

    Transform player;
    // enumerator to make it more efficient than update
    void Start()
    {
        distanceJoint.enabled = false;
        // allows the two game objects to collide with each other
        distanceJoint.enableCollision = true;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("held G");
            // FROM
            lineRenderer.SetPosition(1, transform.position);
            // TO
            lineRenderer.SetPosition(0, player.position);
            distanceJoint.connectedAnchor = player.position;
            distanceJoint.enabled = true;
            lineRenderer.enabled = true;
        } else if (Input.GetKeyUp(KeyCode.G))
        {
            distanceJoint.enabled = false;
            lineRenderer.enabled = false;
        }

    }
    // find closest wall
    void findClosestWall()
    {

    }
    // make boss face player (calculate where player is)
    // maybe attach to player first
    // (later) find closest wall, grappling hook attaches on there
}
