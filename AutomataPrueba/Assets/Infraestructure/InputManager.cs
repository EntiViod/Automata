using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
/// <summary>
///Button List
/// </summary>
 //"backspace",
 //"delete",
 //"tab",
 //"clear",
 //"return",
 //"pause",
 //"escape",
 //"space",
 //"up",
 //"down",
 //"right",
 //"left",
 //"insert",
 //"home",
 //"end",
 //"page up",
 //"page down",
 //"f1",
 //"f2",
 //"f3",
 //"f4",
 //"f5",
 //"f6",
 //"f7",
 //"f8",
 //"f9",
 //"f10",
 //"f11",
 //"f12",
 //"f13",
 //"f14",
 //"f15",
 //"0",
 //"1",
 //"2",
 //"3",
 //"4",
 //"5",
 //"6",
 //"7",
 //"8",
 //"9",
 //"!",
 //"\"",
 //"#",
 //"$",
 //"&",
 //"'",
 //"(",
 //")",
 //"*",
 //"+",
 //",",
 //"-",
 //".",
 //"/",
 //":",
 //";",
 //"<",
 //"=",
 //">",
 //"?",
 //"@",
 //"[",
 //"\\",
 //"]",
 //"^",
 //"_",
 //"`",
 //"a",
 //"b",
 //"c",
 //"d",
 //"e",
 //"f",
 //"g",
 //"h",
 //"i",
 //"j",
 //"k",
 //"l",
 //"m",
 //"n",
 //"o",
 //"p",
 //"q",
 //"r",
 //"s",
 //"t",
 //"u",
 //"v",
 //"w",
 //"x",
 //"y",
 //"z",
 //"numlock",
 //"caps lock",
 //"scroll lock",
 //"right shift",
 //"left shift",
 //"right ctrl",
 //"left ctrl",
 //"right alt",
 //"left alt"
public class InputManager : MonoBehaviour
{
    public static InputManager instance = null;
    public delegate void ExecuteFunction();
    
    Dictionary<KeyCode, Command> inputs;
    Dictionary<string, Command> keyInputs;
    protected virtual void Awake()
    {
        Assert.IsTrue(FindObjectsOfType<InputManager>().Length < 2,
           getDebugStrLine(31) + "GameManager has more than 1 copy. It's a singleton Class and there can only be one GameManager for each game");
        Assert.raiseExceptions = true;

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
            Destroy(this);

        inputs = new Dictionary<KeyCode, Command>();
        keyInputs = new Dictionary<string, Command>();
    }

    public static void SetInputs(KeyCode code, Command func)
    {
        if(instance != null)
        instance.inputs[code] = func;
    }

    public static void SetInputs(string code, Command func)
    {
        if (instance != null)
        instance.keyInputs[code] = func;
    }

    private void Update()
    {
        foreach(KeyCode k in inputs.Keys)
        {
            if(Input.GetKeyDown(k))
            {
                inputs[k].Execute();
            }
        }

        foreach(string k in keyInputs.Keys)
        {
            
            if(Input.GetButton(k))
            {
                keyInputs[k].Execute();
            }
            if(Input.GetButtonUp(k))
            {
                keyInputs[k].Up();
            }
        }
    }
    string getDebugStrLine(int numLine)
    {
        string str = "GameManager.cs --- line " + numLine + " :";

        return str;
    }

    

}
