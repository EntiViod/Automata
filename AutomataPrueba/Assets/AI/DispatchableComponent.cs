using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DispatchableComponent : MonoBehaviour
{


    public abstract void Dispatch(Message m);
}
