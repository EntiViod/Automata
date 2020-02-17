using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DispatchableComponent : MonoBehaviour
{

 
    public virtual void Dispatch(Message m) {
        
    }
}
