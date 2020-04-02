using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveObjectManager : ScriptableWizard
{

    public string filter;
    [MenuItem("Save/Save Object...")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard("SaveObject", typeof(SaveObjectManager), "Save");
    }
    private void OnWizardCreate()
    {
          //  foreach (Component b in Selection.activeGameObject.GetComponents())
            DataPersistenceManager.saveJson(Selection.activeObject, Application.persistentDataPath + Selection.activeObject.name + ".json");
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
