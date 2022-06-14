using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float attackRate = 2f;
    float nextAttack = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // attack rate doesn't seem to be slowing down attack?
        if(Time.time >= nextAttack)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Shoot();
                nextAttack = Time.time + 1f / attackRate;
            }
        }
    }

    void Shoot()
    {
        Debug.Log("fire");

        if (bulletPrefab == null)
            Debug.Log("bullet prefab is null");
        // shooting logic
        Debug.Log(Instantiate(bulletPrefab, firePoint.position, firePoint.rotation));
    }
}
