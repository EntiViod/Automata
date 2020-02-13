using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class life : DispatchableComponent
{
 
    public float myLife = 100;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DamageMessage m = new DamageMessage(transform, transform, typeof(life), 10);

            MessageManager.get().SendMessage(m);
        }
       
    }

    public  override void Dispatch(Message m)
    {
        myLife -= ((DamageMessage)m).damage;

    }
}
