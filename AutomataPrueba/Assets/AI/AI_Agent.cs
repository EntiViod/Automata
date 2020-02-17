using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AI_Agent : MonoBehaviour
{

    
    private stateFunction actualState;
    public delegate void stateFunction();
    public delegate bool conditionFunction();
    

    private Dictionary<string, stateFunction> states;
    private Dictionary<string, conditionFunction> conditions;

    struct State
    {
        public stateFunction execFunction;
        public string entryFunction;
        public conditionFunction exitFunction;
    }

    float angleVelocity = 15.0f;
    float velocity = 1.0f;
    public void idleF()
    {

    }
    private void Awake()
    {
        
        states = new Dictionary<string, stateFunction>();
    }
    public virtual void updateAgent()
    {
        actualState();
      

        
    }

   

    bool calculateDistance()
    {
      
        return true;
    }

    protected stateFunction getState(string stateName)
    {
       
        if (states.ContainsKey(stateName))
        {
            return states[stateName];

        }
     
        Debug.LogError("WRONG STATE");
        return null;
    }

    protected void initState(string stateName,stateFunction func)
    {
        if(states.ContainsKey(stateName))
        {
            Debug.LogError("Repeated Key Value");
            return;
        }
        states[stateName] = func;
    }
    
    protected void setState(stateFunction func)
    {
        actualState = func;
    }
 
}
