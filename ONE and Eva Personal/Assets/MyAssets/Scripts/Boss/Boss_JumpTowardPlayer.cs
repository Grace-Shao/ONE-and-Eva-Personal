using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// delete this script if jump doesn't work
public class Boss_JumpTowardPlayer : MonoBehaviour
{

    [SerializeField] float jumpHeight;
    [SerializeField] Transform player, groundCheck;
    [SerializeField] Vector2 boxSize;
    [SerializeField] LayerMask groundLayer;
    private Rigidbody2D bossRB;
    private Animator animator;
    public bool isGrounded;
    public bool jump = false;

    void Start()
    {
        bossRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        if (Input.GetKeyDown(KeyCode.J))
        {
            JumpAttack();
        }
    }

    void FixedUpdate()
    {
        //jump = false; // stops the boss from jumping in fixed frames
    }

    void JumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;
        Debug.Log("dist from player " + distanceFromPlayer);
        if (isGrounded && jump == false)
        {
            jump = true;
            // AddForce, Force is applied continuously along the direction of the force vector.
            //forceMode impulse, changes velocity, affected by mass, applies 
            bossRB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
            animator.SetBool("IsJumping", true);
            // wait a bit or else next if statement fires off immedeatly, turning isJumping off too soon
            // and not playing the ending animation
            StartCoroutine(wait1sec());
        }
        if (isGrounded && jump == true)
        {
            jump = false;
            animator.SetBool("IsJumping", false);
        }
    }

    IEnumerator wait1sec()
    {
        yield return new WaitForSeconds(5);
    }

    //draw the ground check box
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(groundCheck.position, boxSize);
    }
}
