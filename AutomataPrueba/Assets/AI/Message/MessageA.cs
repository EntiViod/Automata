using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
 public abstract class Message 
{

    public Transform receiver;
    public Transform sender;
    public System.Type senderComp;
    public string mssg_type;

    public Message() { }
    public  Message(Message m)
    {

    }
    public  T Cast<T>(object o)
    {
        return (T)o;
    }

    public abstract Message createCopy();
    

    public static Message MessageFactory(string name)
    {
        switch(name.ToLower())
        {
            case "damage":
                return new DamageMessage();
            case "default":
                return null;
            
        }
        return null;
    }
};

public class DamageMessage :  Message
{
    public float damage;
    public DamageMessage() { }
    public  DamageMessage(Transform send, Transform receiver, 
        System.Type senderComponent, float damage)
    {
        sender = send;
        this.receiver = receiver;
        senderComp = senderComponent;
        this.damage = damage;
        mssg_type = "damage";
    }

   
    public override Message createCopy()
    {
        Message m = new DamageMessage(receiver, sender, senderComp, damage);
        return m;
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


public class ChatMessage : Message
{
    string chatMessage = "Hello World";
   
    public ChatMessage(Transform send, Transform receiver,
     System.Type senderComponent, string mssg)
    {
        sender = send;
        this.receiver = receiver;
        senderComp = senderComponent;
        this.chatMessage = mssg;
        mssg_type = "chat";
    }
    public override Message createCopy()
    {
        Message newMessage = new ChatMessage(receiver,sender,senderComp,chatMessage);

        return newMessage;
    }
}

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
