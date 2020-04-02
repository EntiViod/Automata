using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : DispatchableComponent
{
    [SerializeField]
    float life = 100;
    public override void Dispatch(Message m)
    {
        DamageMessage mD = ((DamageMessage)m);
        life -= mD.damage;

        mD.sender.gameObject.SetActive(false);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
