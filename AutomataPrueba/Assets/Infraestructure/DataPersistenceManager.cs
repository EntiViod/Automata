using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class DataPersistenceManager 
{
    public static void saveJson(Object data,string jsonPath )
    {
        
       string json = JsonUtility.ToJson(data);


        System.IO.File.WriteAllText(jsonPath, json);
    }

    public static T loadJson<T>(string jsonPath)
    {
        
        return JsonUtility.FromJson<T>(System.IO.File.ReadAllText(jsonPath));
    }

}
