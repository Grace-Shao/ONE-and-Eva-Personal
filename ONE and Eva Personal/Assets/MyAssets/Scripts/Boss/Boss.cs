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
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

}