using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ability : Command,IEntity
{
    
    protected FirstPersonCharacter character;
    protected float cooldownTime;
    protected float abilityTimer;

    public void InitAbility(FirstPersonCharacter charac)
    {
        character = charac;
    }

  
    public void UseAbility()
    {

    }
   
    public virtual void EAwake()
    {
        
    }

    public virtual void EUpdate(float delta)
    {

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
