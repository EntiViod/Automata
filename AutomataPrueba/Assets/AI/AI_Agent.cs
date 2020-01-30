using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Agent : MonoBehaviour
{
    private stateFunction actualState;
    public delegate void stateFunction();
    private Dictionary<string, stateFunction> states;

    private void Awake()
    {
        states = new Dictionary<string, stateFunction>();
    }
    public virtual void updateAgent()
    {
        actualState();
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
        states[stateName] = func;
    }
    
    protected void setState(stateFunction func)
    {
        actualState = func;
    }
 
}
