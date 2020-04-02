using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        Message m = new DamageMessage(transform,other.transform,typeof(Damageable),5.0f);
        MessageManager.get().SendMessage(m);
        
    }
}
