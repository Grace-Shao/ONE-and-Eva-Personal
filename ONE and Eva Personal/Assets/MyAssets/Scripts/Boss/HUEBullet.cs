using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUEBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed * -1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    // whenever bullet hits something
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log("bullet hit " + hitInfo.name);


        // if the bullet hits ONE
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            PlayerHealth player = hitInfo.GetComponent<PlayerHealth>();

            if (player != null)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
