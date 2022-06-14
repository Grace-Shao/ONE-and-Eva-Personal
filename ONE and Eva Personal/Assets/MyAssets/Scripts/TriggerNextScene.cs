using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextScene : MonoBehaviour
{
    public LevelLoader levelLoader;
    void OnTriggerEnter2D(Collider2D collision)
    {

        // Debug.Log("trigger");
        if (collision.gameObject.tag == "Player")
        {
            levelLoader.LoadNextLevel();
        }

    }
}
