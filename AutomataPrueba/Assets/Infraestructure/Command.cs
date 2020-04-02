using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Command : MonoBehaviour
{
    public virtual void Up()
    {

    }
    public virtual void Execute()
    {
        Debug.Log("Input");
    }
 
}
 