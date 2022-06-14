using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
	[SerializeField]
	private GameObject shockWaveVisualizer;
	private bool _isShockWaveEnabled = false;
	public int aoeDamage = 100;
	public float aoeRadius = 5;

	public int attackDamage = 20;
	public int enragedAttackDamage = 40;

	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;

	// shooting attack
	public Transform firePoint;
	public GameObject bulletPrefab;
	private float timeBtwShots;
	public float startTimeBtwShots;

    void Update()
    {
		// shot attack + AoE attack
		if (timeBtwShots <= 0)
		{
			Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
			timeBtwShots = startTimeBtwShots;
			// enable the aoe attack
			ShockWaveEnabled();
			// start aoe attack
			if (_isShockWaveEnabled == true)
			{
				StartCoroutine(ShockwaveRoutine());
			}
		}
        else
        {
			timeBtwShots -= Time.deltaTime;
        }
	}

	// the attack is happening as an animation event in state machine
    public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
		}
	}
	
	// not used yet, can use when enraged animation is made. then assign this function to the event.
	public void EnragedAttack()
	{
		Debug.Log("Enraged Mode");
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().TakeDamage(enragedAttackDamage);
		}
	}

	void OnDrawGizmosSelected()
	{

		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		// white is attack radius
		Gizmos.DrawWireSphere(pos, attackRange);

		// draw the aoe attack
		Gizmos.color = new Color(1, 1, 0, 0.75F);
		Gizmos.DrawWireSphere(pos, aoeRadius);
	}

	// aoe attack
	private void AreaOfEffectDamage()
	{
		Vector2 origin = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
		Collider2D[] colliders = Physics2D.OverlapCircleAll(origin, aoeRadius, attackMask);
		// delete later
		if (colliders.Length == 0)
			Debug.Log("length is 0");
		foreach (Collider2D c in colliders)
		{
			if (c.GetComponent<PlayerHealth>())
			{
				Debug.Log("Colliders found");
				c.GetComponent<PlayerHealth>().TakeDamage(aoeDamage);
			}
		}
	}

	public void ShockWaveEnabled()
    {
		_isShockWaveEnabled = true;
    }

	IEnumerator ShockwaveRoutine()
    {
		Debug.Log("Shockwave");
		shockWaveVisualizer.SetActive(true);
		// for every child object in shockWaveVisualizer, turn it on.
		for (int a = 0; a < shockWaveVisualizer.transform.childCount; a++)
		{
			shockWaveVisualizer.transform.GetChild(a).gameObject.SetActive(true);
		}
		yield return new WaitForSeconds(0.5f);
		AreaOfEffectDamage();
		yield return new WaitForSeconds(1.0f);
		shockWaveVisualizer.SetActive(false);
		_isShockWaveEnabled = false;
    }

}