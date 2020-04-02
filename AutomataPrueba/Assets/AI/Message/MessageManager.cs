using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class MessageManager : MonoBehaviour
{
    static MessageManager instance = null;
    DispatchableComponent[] dispatchableComponents;
    Stack<Message> myQ;
    Dictionary<string, System.Type> mssgTypes;
    

    private void Awake()
    {
       
        if (instance != null)
        {
            Destroy(gameObject);return;
        }
        instance = this;
        myQ = new Stack<Message>();
        initMessages();
       
    }

    private void initMessages()
    {
        mssgTypes = new Dictionary<string, Type>();
        mssgTypes["damage"] = typeof(DamageMessage);
        mssgTypes["chat"] = typeof(ChatMessage);
    }

    public System.Type getMessageType(string type)
    {
        return mssgTypes[type];
    }


    private void Start()
    {
        dispatchableComponents = FindObjectsOfType<DispatchableComponent>();
    }
    public static MessageManager get()
    {

        return instance;
    }

    void Update()
    {

        DispatchMessage();
    }

    void removeDispatchtableComponent(DispatchableComponent del)
    {
        dispatchableComponents = dispatchableComponents.Where(d => d != del).ToArray();
    }
    void addDispatchableComponent(DispatchableComponent newComp)
    {
       
    }

   

    public void SendMessageToAll(Message m)
    {
       DispatchableComponent[] receiverCmpnts =
       dispatchableComponents.Where(c => c.GetType() == m.senderComp).ToArray();
        Message newMessage;
        foreach (DispatchableComponent dc in receiverCmpnts)
        {
            
            newMessage = m.createCopy();
            newMessage.receiver = dc.transform;
       
            myQ.Push(newMessage);
          
            
        }

    }

    public void RegisterComponentToMessageType(System.Type messageType, Component cmp)
    {

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

        }
        myQ.Clear();
    }
}
