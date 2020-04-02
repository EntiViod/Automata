using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOrc : ConsoleFunction
{

    public SpawnOrc(int numberOfParameters, params CONSOLE_DATATYPE[] parameters) : base(numberOfParameters, parameters)
    {

    }

    void parseItem( string parameter, CONSOLE_DATATYPE type)
    {
        if(type == CONSOLE_DATATYPE.NUMERIC)
        {
            numericValues.Add(float.Parse(parameter));
        }
    }

    public override bool Execute(params object[] parameters)
    {
        if (parameters.Length != this.parameters.Length)
            return false;

       
        

        Vector3 position = new Vector3(float.Parse((string)parameters[0]), float.Parse((string)parameters[1]), float.Parse((string)parameters[2]));
        Debug.Log("SPAWN AT: " + position);
        return true;
        
    }

    public override string FunctionArgumentsDenition()
    {
        return "Function Expects: X(float), Y(float), Z(float)";
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
