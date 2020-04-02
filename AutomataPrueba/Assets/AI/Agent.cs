using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public enum ENABLEDSTATES
    {
        WANDER = 1 << 0,
        FLEE = 1 << 1,
        SEEK = 1 << 2,
        AVOIDANCE = 1 << 3,
        PURSUIT = 1 << 4,
        ALL = WANDER | FLEE | SEEK | AVOIDANCE | PURSUIT
    }
    public Vector3 velocity;
    public Vector3 separationVector;
    public List<Agent> neightbours;
    public Vector3 startVector;


    float maxForce = 10.0f;
    float mass = 1.0f;
    float maxVelocity = 5.0f;
    public float wanderCircleDist = 5.0F, circleRadius = 5.0f, wanderAngle = 45.0f;

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, transform.position + velocity);
        Gizmos.DrawWireSphere(transform.position, 2);
        Dictionary<string, int> p = new Dictionary<string, int>();
        p["hola"] = 1;
        p.ContainsKey("hola");
        int e;
        //p.TryGetValue("hola", ref e);
    }

    public void updateAgent()
    {
        transform.position += velocity * Time.deltaTime ;
    }
    private void Awake()
    {
        neightbours = new List<Agent>();
    }

    public void addForce(Vector3 f)
    {
        f = Vector3.ClampMagnitude(f, maxForce);
        f /= mass;
        velocity += f;
        velocity = Vector3.ClampMagnitude(velocity, maxVelocity);
    }
    // Start is called before the first frame update
    void Start()
    {
        ENABLEDSTATES p = ENABLEDSTATES.AVOIDANCE | ENABLEDSTATES.PURSUIT;
        //if(p & ENABLEDSTATES.AVOIDANCE == ENABLEDSTATES.AVOIDANCE)
        //{

        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
