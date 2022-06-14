using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ONEBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // whenever bullet hits something
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("ONE's bullet hit " + hitInfo.name);

        // if the bullet hits enemy
        if(hitInfo.gameObject.CompareTag("Enemy"))
        {
            // could be boss or enemy
            if(hitInfo.GetComponent<BossHealth>())
            {
                BossHealth enemy = hitInfo.GetComponent<BossHealth>();
                enemy.TakeDamage(damage);
            }
            else if(hitInfo.GetComponent<Robot_Health>())
            {
                Robot_Health enemy = hitInfo.GetComponent<Robot_Health>();
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
