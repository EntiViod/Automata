using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public interface ChangeLife: IEventSystemHandler
{
    void Damage(float dmg);
    void Healing(float healing);
}

public class Message_Unity : MonoBehaviour,ChangeLife
{
    [SerializeField]
    GameObject target;
    public void Damage(float dmg)
    {
        Debug.Log("Damage for " + dmg);
    }

    public void Healing(float healing)
    {
        Debug.Log("Healing for " + healing);
        
    }

    void damageMessage(ChangeLife handler, BaseEventData eventData)
    {
        handler.Damage(50);
    }
    // Start is called before the first frame update
    void Start()
    {
        
        ExecuteEvents.Execute<ChangeLife>(target, null, (a, b) => a.Damage(50));
        ExecuteEvents.Execute<ChangeLife>(gameObject, null, damageMessage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
