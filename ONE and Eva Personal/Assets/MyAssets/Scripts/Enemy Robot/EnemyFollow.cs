//https://youtu.be/rhoQd6IAtDo
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public int hitboxDist = 10;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // only travel in y pos
        var targetPos = new Vector2(target.position.x, transform.position.y);
        if(Vector2.Distance(transform.position, target.position) < hitboxDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            GetComponent<EnemyPatrol>().enabled = false;    // turn this script off
            GetComponent<Enemy_Attack>().Attack();
        }
        else
        {
            GetComponent<EnemyPatrol>().enabled = true;
        }
        
    }
}
