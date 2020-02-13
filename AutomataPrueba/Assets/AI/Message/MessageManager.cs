using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    static MessageManager instance = null;
    Stack<Message> myQ;
    private void Awake()
    {
       
        if (instance != null)
        {
            Destroy(gameObject);return;
        }
        instance = this;
        myQ = new Stack<Message>();
    }

    public static MessageManager get()
    {

        return instance;
    }

    void Update()
    {
       
      
        DispatchMessage();
    }

    public void SendMessage(Message m)
    {
        if (m.receiver.GetComponent(m.senderComp) == null) return;
        myQ.Push(m);
    }
    public void DispatchMessage()
    {
        foreach(Message m in myQ)
        {

            ((DispatchableComponent) m.receiver.GetComponent(m.senderComp)).Dispatch(m);

            //m.receiver.GetComponent<Entity>().Dispatch(m);
            //if(m.GetType() == typeof(DamageMessage))
            //{
            //    m.receiver.GetComponent<DamageComponent>().Dispatch(m);
            //}
            //else if()
            //{  

            //}
        }
        myQ.Clear();
    }
}
