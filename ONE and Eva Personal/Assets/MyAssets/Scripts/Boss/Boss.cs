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

	public bool isFlipped = false;

    public void Start()
    {
		player = GameObject.FindWithTag("Player").transform;
		animator = GetComponent<Animator>();
    }

    public void Update()
    {
		GrappleRandomly();
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
		Debug.Log("time" + time);
		if (time % 1000 == 0)
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

}