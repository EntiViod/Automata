using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    public GameObject target;
    public static int ManhattanDistance(Vector3 a , Vector3 b)
    {
        checked
        {
            return Mathf.Abs((int)a.x - (int)b.x) + Mathf.Abs((int)a.y - (int)b.y) + 
                Mathf.Abs((int)a.z - (int)b.z);
        }
    }

    private void OnDrawGizmos()
    {
        if(ManhattanDistance(transform.position, target.transform.position) <= 1)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 5.0f);
        }
    }
    public void Update()
    {
        Debug.Log(ManhattanDistance(transform.position, target.transform.position));
    }

}
