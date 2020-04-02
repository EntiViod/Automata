using System.Collections.Generic;
using UnityEngine;

public class ConsoleManager : MonoBehaviour
{ 
    Dictionary<string, ConsoleFunction> consoleFunctions;

    ChatWindow consolePrefab;
    const char separator = ' ';
    const char commandStarter = '/';
    public static ConsoleManager instance;

  
    // Start is called before the first frame update
    void Start()
    {
        consolePrefab = FindObjectOfType<ChatWindow>();
        //ConsoleFunction orcSpawn = ;
        consoleFunctions = new Dictionary<string, ConsoleFunction>();
        consoleFunctions.Add(nameof(SpawnOrc), new SpawnOrc(3, ConsoleFunction.CONSOLE_DATATYPE.NUMERIC, ConsoleFunction.CONSOLE_DATATYPE.NUMERIC, ConsoleFunction.CONSOLE_DATATYPE.NUMERIC));

        string mssg = "/SpawnOrc 10 40 50";
      
        DispatcheMessage(mssg);

    }

    public void DispatcheMessage(string mssg)
    {
        if (consolePrefab != null)
        {
            consolePrefab.SendeMessageToChat(mssg, ChatWindow.eMessageTYPE.REGULAR);
            if (mssg[0] == commandStarter)
            {
                mssg = mssg.Substring(1);

                string[] eMessageContainer = mssg.Split(separator);
                string[] parameters = new string[eMessageContainer.Length - 1];
                if (eMessageContainer[0] == "help")
                {
                    foreach (ConsoleFunction cF in consoleFunctions.Values)
                    {
                        consolePrefab.SendeMessageToChat("Function " + cF.GetType().Name + " " + cF.FunctionArgumentsDenition(), ChatWindow.eMessageTYPE.HELP);


                    }
                    return;
                }
                System.Array.Copy(eMessageContainer, 1, parameters, 0, eMessageContainer.Length - 1);

                if (consoleFunctions.ContainsKey(eMessageContainer[0]))
                {
                    if (!consoleFunctions[eMessageContainer[0]].Execute(parameters))
                    {
                        consolePrefab.SendeMessageToChat("Wrong number of arguments, function expects " + consoleFunctions[eMessageContainer[0]].FunctionArgumentsDenition(), ChatWindow.eMessageTYPE.DANGER);
                        Debug.LogWarning("Wrong number of arguments, function expects " + consoleFunctions[eMessageContainer[0]].FunctionArgumentsDenition());
                    }
                }
                else
                {
                    consolePrefab.SendeMessageToChat("No function data on found by the name of: " + eMessageContainer[0] + "Type /help to see availables functions", ChatWindow.eMessageTYPE.DANGER);

                    Debug.LogWarning("No function data on found by the name of: " + eMessageContainer[0] + "Type /help to see availables functions");
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
