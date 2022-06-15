using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// boss scripts from brackeys boss vid
public class Boss : MonoBehaviour
{

	private Transform player;

	public bool isFlipped = false;

    public void Start()
    {
		player = GameObject.FindWithTag("Player").transform;
    }

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

}