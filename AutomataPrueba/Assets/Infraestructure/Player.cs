using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public string name = "Hello";
    public float force = 50;
    public float weapon = 80;
    // Start is called before the first frame update
    void Start()
    {

        DataPersistenceManager.saveJson(this, Application.persistentDataPath + "Prueba.json");

        Player p = DataPersistenceManager.loadJson<Player>(Application.persistentDataPath);

        Debug.Log(Application.persistentDataPath);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
