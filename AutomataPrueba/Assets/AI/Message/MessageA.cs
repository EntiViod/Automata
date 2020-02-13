using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
 public class Message 
{

    public Transform receiver;
    public Transform sender;
    public System.Type senderComp;

    public Message() { }
    
    public  T Cast<T>(object o)
    {
        return (T)o;
    }
};

public class DamageMessage :  Message
{
    public float damage;
    public DamageMessage() { }
    public DamageMessage(Transform send, Transform receiver, System.Type senderComponent, float damage)
    {
        sender = send;
        this.receiver = receiver;
        senderComp = senderComponent;
        this.damage = damage;

       
    }

    public bool SetMessageAndSendMessage(Transform send, Transform receiver, System.Type senderComponent, float damage)
    {
        sender = send;
        this.receiver = receiver;
        senderComp = senderComponent;
        this.damage = damage;

        if (receiver.GetComponent(senderComponent) == null) return false;
        MessageManager.get().SendMessage(this);
        return true;

    }
   
};

public class MessageA : MonoBehaviour
{
    Transform senderEntity;
    Transform receiverEntity;


    // Start is called before the first frame update
    void Start()
    {
      
        

    }

    // Update is called once per frame
    void Update()
    {

    }
}
