using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

// later I want it to be if you walk across the obj, u can only see the 
// dialogue once

public class onTriggerDialogue : MonoBehaviour
{
    public NPCConversation myConversation;

    // plays dialogue once
    private bool istriggered = false;
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (istriggered == false)
        {
            // Debug.Log("trigger");
            if (collision.gameObject.tag == "Player")
            {
                ConversationManager.Instance.StartConversation(myConversation);
            }
            istriggered = true;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        istriggered = false;
    }
}

