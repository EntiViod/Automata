using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterpolateThroughPoints : MonoBehaviour
{
    [SerializeField]
    Transform[] transformations;

    float t = 0;
    int actualId = 0;
    float timeDebug = 0.0f;
    Vector3 startingPoint;
    Vector3 startingFwd;
    // Start is called before the first frame update
    void Start()
    {
        t = 0;
        startingPoint = transform.position;
    }

    private void OnDrawGizmos()
    {
        int numSamples = 10;
        for (int i = 0; i < numSamples; i++)
        {
            
            float ratio = Interpolators.bounceInOut(0, 1, (float)i/(float)numSamples);
        
            Gizmos.DrawWireSphere(Vector3.Lerp(startingPoint,
                transformations[0].position,ratio),0.1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float ratio = Interpolators.expoOut(0, 1, t);

     
        transform.position = Vector3.Lerp(startingPoint,
        transformations[actualId].position, ratio);


        t += Time.deltaTime;
        if(t >= 1.0f)
        {
            actualId++;
            actualId %= transformations.Length;
            t = 0.0f;
        }
        
    }
}
