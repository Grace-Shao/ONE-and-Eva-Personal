using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class DialogueStartImmed : MonoBehaviour
{
    public NPCConversation myConversation;
    public static bool isTalking = false;
    // Start is called before the first frame update
    void Start()
    {
        ConversationManager.Instance.StartConversation(myConversation);
    }

    // Update is called once per frame
    void Update()
    {
        if(ConversationManager.Instance.IsConversationActive == true)
        {
            isTalking = true;
        }
        else
        {
            isTalking = false;
        }
    }

    /*
    private void OnMouseOver()
    {
       if(Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(myConversation);
        }
    }
    */


}
