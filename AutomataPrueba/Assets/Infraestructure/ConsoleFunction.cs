using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public abstract class ConsoleFunction 
{
    /*
     * 
     * ConsoleFunction(int params) //Parametros que vamos a pasar.
     */

    public enum CONSOLE_DATATYPE
    {
        NUMERIC,
        STRING
    }

    protected int numberParameters;
    protected CONSOLE_DATATYPE[] parameters;

    //protected List<string> stringValues;
    protected List<double> numericValues;
    private ConsoleFunction() { }

    protected ConsoleFunction(int numberOfParameters, params CONSOLE_DATATYPE[] parameters)
    {
        numberParameters = numberOfParameters;
        this.parameters = parameters;
       // stringValues = new List<string>();
        numericValues = new List<double>();
    }

    public abstract bool Execute(params object[] parameters);

    public abstract string FunctionArgumentsDenition();

    
    void helpWithMethods(string myMethod)
    {

    }

    protected void helpWithMethods()
    {

        //typeof(ConsoleFunction).GetMethod("myFunction").GetParameters()
        foreach (MethodInfo method in this.GetType().GetMethods(BindingFlags.Instance | BindingFlags.NonPublic))
        {
            foreach(ParameterInfo info in method.GetParameters())
            {
               
                Debug.Log(method.Name + " : " + info.Name + " TypeOf: ("+ info.ParameterType +")");
                
            }
        }
    }

}
