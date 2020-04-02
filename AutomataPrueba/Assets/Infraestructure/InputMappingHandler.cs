using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

public class InputMappingHandler : ScriptableWizard
{
    public KeyCode code;
    public Command cmd;
    
    // Start is called before the first frame update
    [MenuItem("Input/Input Binding...")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("Input Map", typeof(InputMappingHandler), "Bind");
    }

    private void OnWizardCreate()
    {
        //if (System.Type.GetType(className) == null) { Debug.LogError("Class Doesn't exist!"); return; }
        //if(System.Type.GetType(className).GetMethod(functionName) == null) { Debug.LogError("Function Doesn't exist"); return; }
        //if(System.Type.GetType(className).GetMethod(functionName).ReturnType != typeof(void) || 
        //    System.Type.GetType(className).GetMethod(functionName).GetParameters().Length > 0) { Debug.LogError("Function isn't void or have parameters");return; }
        if (InputManager.instance == null) { Debug.LogError("No inputmanager instance found"); return; }


        //FindObjectOfType <typeof(System.Type.GetType(className))>()
        InputManager.SetInputs(code, cmd);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
