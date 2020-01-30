using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class patrol : AI_Agent
{
    Vector3[] waypoints;
    Transform target; 
    public int maxWaypoints = 10;
    int actualWaypoint = 0;

    void initPositions()
    {
        List<Vector3> waypointsList = new List<Vector3>();
        float anglePartition = 360.0f / (float)maxWaypoints;
        for (int i = 0; i < maxWaypoints; ++i)
        {
            Vector3 v = transform.position + 5 *  Vector3.forward * Mathf.Cos(i* anglePartition) 
                + 5* Vector3.right * Mathf.Sin(i*anglePartition);
            waypointsList.Add(v);

        }
        waypoints = waypointsList.ToArray();
    }

    private void OnDrawGizmos()
    {
        if (waypoints.Length > 0)
        {
            for (int i = 0; i < maxWaypoints; i++)
            {
                Gizmos.DrawSphere(waypoints[i], 1.0f);
            }
        }
    }

    void idle()
    {
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            setState(getState("goto")) ;
        }
    }


    
    void goToWaypoint()
    {
        Debug.Log("waypointHey");
    }

    void calculateNextWaypoint()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        //states["idle"] = idle;
        //states["goto"] = goToWaypoint;
        //states["nextwp"] = calculateNextWaypoint;
        //states["ahora"] = () => { Debug.Log("hey"); };

        initPositions();
        actualWaypoint = 0;
        initState("idle", idle);
        initState("goto", goToWaypoint);
        initState("nextwp", calculateNextWaypoint);
        
        setState(getState("idle"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
