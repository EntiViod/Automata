using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System.Reflection;
using System.Diagnostics;
using System.Linq;



public class GameManager : MonoBehaviour
{

    public static void Log(object item)
    {
#if _DEBUG
        UnityEngine.Debug.Log(item);
  
#endif
    }
    public static GameManager instance = null;
#if _CONSOLE

    public ConsoleManager console;
#endif
    [SerializeField]
    List<IEntity> entities;
    [SerializeField]
    ObjPooler pool;
   
    void Awake()
    {

        /*Obj Pooler*/
        if (pool == null)
            pool = FindObjectOfType<ObjPooler>();


        StackFrame callStack = new StackFrame(1, true);
        //Assert.IsTrue(FindObjectsOfType<GameManager>().Length < 2,
        //   callStack.GetFileLineNumber() + " " + callStack.GetFileName() +  " has more than 1 copy. It's a singleton Class and there can only be one for each game " + callStack.GetMethod().Name);
        //Assert.raiseExceptions = true;
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);

#if _CONSOLE
        console = gameObject.AddComponent<ConsoleManager>();
        ConsoleManager.instance = console;
#endif
        entities = new List<IEntity>();
        var entitiesI = FindObjectsOfType<MonoBehaviour>().OfType<IEntity>();
        
        foreach(IEntity ent in entitiesI)
        {
            entities.Add(ent);
        }
        
        
        
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(IEntity ent in entities)
        {
            ent.EAwake();
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (IEntity ent in entities)
        { 
            if((ent as MonoBehaviour).enabled)
            ent.EUpdate(Time.deltaTime);
        }
    }
}
