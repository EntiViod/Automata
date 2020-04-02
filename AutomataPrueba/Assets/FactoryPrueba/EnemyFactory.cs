using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EnemyFactory 
{

    public delegate Enemy EnemyCreationFunc();
    static Dictionary<string, EnemyCreationFunc> enemyFactory
        = new Dictionary<string, EnemyCreationFunc>();

    static Enemy CreateEnemy(System.Type type,GameObject gm)
    {
        
        //System.Activator.CreateInstance(type); 
        return enemyFactory[type.Name]();
    }

    static void RegisterNewType(string type,EnemyCreationFunc fnc)
    {
        enemyFactory.Add(type,fnc);
    }
}
