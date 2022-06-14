using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public float distance;

    private bool movingRight = true;

    public Transform groundDetection;

    void Update()
    {
        // moves right
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
        // if nothing is detected on ground
        if(groundInfo.collider == false)
        {
            // if move right, then move it right
            if(movingRight == true)
            {
                // rotate the sprite 180
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            // if move left
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

}
