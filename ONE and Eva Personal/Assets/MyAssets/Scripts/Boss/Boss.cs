using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// boss scripts from brackeys boss vid
// also responsible for controlling grapple boolean for now
public class Boss : MonoBehaviour
{

	private Transform player;
	private Animator animator;
	float time = 0;

	[SerializeField] private Transform groundCheck;
	[SerializeField] private LayerMask whatIsGroundMask;
	public bool isFlipped = false;

    public void Start()
    {
		player = GameObject.FindWithTag("Player").transform;
		animator = GetComponent<Animator>();
		animator.SetBool("isGrounded", false);
    }

    public void Update()
    {
		GrappleRandomly();
		checkGrounded();
    }
    // this method gets called in other scripts
    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			Debug.Log("Right side + " + isFlipped);
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
			Debug.Log("Right side2 + " + isFlipped);
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			Debug.Log("Left side + " + isFlipped);
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
			Debug.Log("Left side2 + " + isFlipped);
		}
	}

	public void GrappleRandomly()
    {
		time += (float)Math.Ceiling(Time.deltaTime);
		time = (float)Math.Ceiling(time);
		if (time % 5000 == 0)
        {
			Debug.Log("Grappling");
			StartCoroutine(grappleForXSec(5));
        }
    }

	IEnumerator grappleForXSec(int x)
    {
		animator.SetBool("isGrapple", true);
		yield return new WaitForSeconds(x);
		animator.SetBool("isGrapple", false);
	}

	// checks if boss is grounded
	private void checkGrounded()
    {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, .2f, whatIsGroundMask);
		if (colliders.Length == 0)
        {
			animator.SetBool("isGrounded", false);
		}
		for (int i = 0; i < colliders.Length; i++)
        {
			// if collides w something other then itself
			if (colliders[i].gameObject != gameObject)
			{
				Debug.Log("boss collided");
				animator.SetBool("isGrounded", true);
			}
        }
    }

}