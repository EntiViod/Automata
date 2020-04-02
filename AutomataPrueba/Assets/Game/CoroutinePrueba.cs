using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutinePrueba : MonoBehaviour
{
    Coroutine abilityCD;
    WaitForSeconds wait;
    
    IEnumerator abilityCooldown()
    {
        
        while (true)
        {
            yield return new WaitForSeconds(0.25f) ;
            Debug.Log("Hola");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        abilityCD = StartCoroutine(abilityCooldown());
        
        StopCoroutine(abilityCD);

        Debug.Log("hello");

        

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
