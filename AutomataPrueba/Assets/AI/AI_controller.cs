using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AI_controller : MonoBehaviour
{
    DamageMessage m;
    public AI_Agent agent; // pointer in c++
   

    // Start is called before the first frame update
    void Start()
    {
        m = new DamageMessage(transform, transform, typeof(life), 10);
    }

    // Update is called once per frame
    void Update()
    {
        //ASSERT
        agent.updateAgent();
        if (Input.GetKeyDown(KeyCode.Q))
        {
           

            MessageManager.get().SendMessage(m);
            ChatMessage chat = new ChatMessage(transform, transform, typeof(life), "Hello");
            MessageManager.get().SendMessageToAll(chat);
        }

    }
}
