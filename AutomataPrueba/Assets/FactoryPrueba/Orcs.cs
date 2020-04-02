using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orcs : Enemy
{
    public Orcs()
    { 

    }

    public override void Attack()
    {
       
    }

    public override Enemy CreateEnemy()
    {
        return new Orcs();
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
