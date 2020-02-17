using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : DispatchableComponent
{

    public float myLife = 100;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if(myLife < 50.0f)
        {
            Gizmos.color = Color.yellow;
        }
         if(myLife<25.0f)
        {
            Gizmos.color = Color.red;
        }
       Gizmos.DrawSphere(transform.position + Vector3.up * 1.0f, 0.5f);
     
       // UnityEditor.Handles.Label(transform.position + Vector3.up, myLife.ToString());
    }
    private void Awake()
    {
     

    }
    // Update is called once per frame
    void Update()
    {
    
    }

    private void Dispatch(System.Type type, Message m)
    {
        if(type == typeof(DamageMessage))
        {
            myLife -= ((DamageMessage)m).damage;
        }
        else
        {
            Debug.Log("Hello");
        }
    }
  
    
    public override void Dispatch(Message m)
    {
   

        System.Type tp = MessageManager.get().getMessageType(m.mssg_type);

        Dispatch(tp,m);

        //if (m as ChatMessage != null)
        //{
            
        //}
        //else if (m as DamageMessage != null)
        //{
            
        //    myLife -= ((DamageMessage)m).damage;
        //}

    }
}
