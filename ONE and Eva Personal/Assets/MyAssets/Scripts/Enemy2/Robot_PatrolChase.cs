using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_PatrolChase : MonoBehaviour
{
    public float speed;
    public float groundDetectDist;
    public float detectDist = 10;

    public bool movingRight = true;
    private Animator animator;

    public Transform groundDetection;
    public Transform lineOfSight;

    LayerMask mask;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //********************Patrol script*******************//
        // moves right
        transform.Translate(Vector2.right * speed * Time.deltaTime);
       
        // dont want raycasts to detect triggers, turn this back on when u do
        Physics2D.queriesHitTriggers = false;
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, groundDetectDist);
        // if nothing is detected on ground
        if (groundInfo.collider == false)
        {
            Debug.Log("ground collider for monster false");
            // if move right, then move it right
            if (movingRight == true)
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

        //*******************line of sight script*******************//
        // make a raycast and see it it hits player
        RaycastHit2D hitPlayer = Physics2D.Raycast(lineOfSight.transform.position, Vector2.right, detectDist);
        if (movingRight)
        {
            Debug.DrawRay(lineOfSight.transform.position, Vector2.right * detectDist, Color.red);
        }
        else if (movingRight == false)
        {
            hitPlayer = Physics2D.Raycast(lineOfSight.transform.position, Vector2.left, detectDist);
            Debug.DrawRay(lineOfSight.transform.position, Vector2.left * detectDist, Color.red);
        }
       
        if(hitPlayer.collider != null)
        {
            Debug.Log("coliider not null, tag " + hitPlayer.collider.tag);
            if (hitPlayer.collider.gameObject.CompareTag("Player"))
            {
                // set isFlipped in boss script to true(unique gimmick, but it works ok?)
                GetComponent<Boss>().isFlipped = true;
                
                transform.eulerAngles = new Vector3(0, 0, 0);
                // turn on run script in animator just like for bosses
                animator.SetBool("isChasing", true);
                GetComponent<Robot_PatrolChase>().enabled = false;

            }
        }


    }

}
