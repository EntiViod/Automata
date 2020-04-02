using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sprint : Ability
{
    [SerializeField]
    float sprintVelocity = 0f;
    [SerializeField]
    float basicVelocity;
    // Start is called before the first frame update

    public override void Up()
    {
        GameManager.Log("End Sprint");
        character.move.speed = basicVelocity ;
    }
    public override void EAwake()
    {
    
        cooldownTime = 0f;
        basicVelocity = character.move.speed;
        sprintVelocity = basicVelocity * 2.0f;
        

    }
    public override  void Execute()
    {
        GameManager.Log("Start Sprint");
        character.move.speed = sprintVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
