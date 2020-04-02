using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;

public interface FloorMessage : IEventSystemHandler
{
    void getFloorInfo(SpatialIndex.FLOOR_STATUS state);
}


[RequireComponent(typeof(BoxCollider))]
public class SpatialIndex : MonoBehaviour
{
    public enum FLOOR_STATUS
    {
        REGULAR = 1<< 0,
        WATER = 1<<1,
        MUD = 1<<2,
        PLAYER = 1<<3,
        LAVA = 1<<4
    }
    [SerializeField]
    float cubeSize = 1.0f;
    [SerializeField]
    int numCubesX = 10;
    [SerializeField]
    int numCubesZ = 10;

    BoxCollider collider;

    FLOOR_STATUS[] floor;

    Vector3 center;
    private void OnDrawGizmos()
    {
        if (Application.isEditor)
        {
            Gizmos.color = Color.yellow;
            Vector3 center =  transform.position - (Vector3.right) * numCubesX / 2 * cubeSize - Vector3.forward * numCubesZ / 2 * cubeSize;

            numCubesX = (int)((GetComponent<BoxCollider>().size.x * transform.localScale.x) / cubeSize);
            numCubesZ = (int)((GetComponent<BoxCollider>().size.z * transform.localScale.z) / cubeSize);
            for (int i = 0; i < numCubesX; i++)
            {
                for (int j = 0; j < numCubesZ; j++)
                {
                    if ((floor[i * numCubesX + j] & FLOOR_STATUS.PLAYER) == FLOOR_STATUS.PLAYER)
                    {
                        Gizmos.color = Color.green;
                    }
                    else if((floor[i * numCubesX + j] & FLOOR_STATUS.WATER) == FLOOR_STATUS.WATER)
                    {
                        Gizmos.color = Color.blue;
                    }
                    else if((floor[i * numCubesX + j] & FLOOR_STATUS.LAVA) == FLOOR_STATUS.LAVA)
                    {
                        Gizmos.color = Color.red;
                    }
                    else
                        Gizmos.color = Gizmos.color = Color.yellow;
                    Gizmos.DrawWireCube(transform.rotation * center + transform.rotation * Vector3.right * cubeSize * i + transform.rotation * Vector3.forward * j, Vector3.one * cubeSize);
                }
            }

        }
        
    }

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //    }
    //    else {
    //        Destroy(gameObject);
    //    }
        
    //}


        /*
         NEVER DO THIS ON UPDATE!!!
         BAKE THE MAP!!!
         */
    void serializeMap()
    {
     
        for (int i = 0; i < numCubesX; i++)
        {
            for (int j = 0; j < numCubesZ; j++)
            {

                if (Physics.CheckBox( center + transform.rotation * Vector3.right * cubeSize * i + transform.rotation *  Vector3.forward * j,Vector3.one * cubeSize / 2.0f, transform.rotation, 1 << 4))
                {
                    floor[numCubesX * i + j] = FLOOR_STATUS.WATER;
                }
                else if(Physics.CheckBox( center + transform.rotation * Vector3.right * cubeSize * i + transform.rotation * Vector3.forward * j, Vector3.one * cubeSize / 2.0f, transform.rotation, 1<<10))
                {
                    floor[numCubesX * i + j] = FLOOR_STATUS.LAVA;
                }
                else
                    floor[numCubesX * i + j] = FLOOR_STATUS.MUD;

            }
        }

       GameObject.FindGameObjectsWithTag("Casters").ToList().ForEach(item => Destroy(item));
    }

    // Start is called before the first frame update
    void Start()
    {
        center =  transform.position - transform.rotation * (Vector3.right) * numCubesX / 2 * cubeSize - transform.rotation * Vector3.forward * numCubesZ / 2 * cubeSize;
        collider = GetComponent<BoxCollider>();
        numCubesX = (int)((collider.size.x * transform.localScale.x) / cubeSize);
        numCubesZ = (int)((collider.size.z * transform.localScale.z) / cubeSize);
        floor = new FLOOR_STATUS[numCubesX * numCubesZ];
        
        for(int i = 0; i<numCubesX;i++)
        {
            for(int j =0; j<5; j++)
            {
                floor[numCubesX * i + j] |= FLOOR_STATUS.WATER;
            }
        }

        serializeMap();
    }


 public FLOOR_STATUS getFloorStatus(float x, float y)
    {
        
        Vector3 localScale = transform.localScale;
        float row =( (x - center.x) / (collider.size.x * localScale.x));
        float col = ((y - center.z) / (collider.size.z * localScale.z));
        int xMap = (int)(Mathf.Abs(row) * numCubesX);
        int yMap = (int)(Mathf.Abs(col) * numCubesZ);
       
        floor[numCubesX * xMap + yMap] |= FLOOR_STATUS.PLAYER;
        return floor[numCubesX * xMap + yMap];
    }

    public void getFloorState(float x, float y, GameObject target)
    {
        
        Vector3 localScale = transform.localScale;
        float row = ((x - center.x) / (collider.size.x * localScale.x));
        float col = ((y - center.z) / (collider.size.z * localScale.z));
        int xMap = (int)(Mathf.Abs(row) * numCubesX);
        int yMap = (int)(Mathf.Abs(col) * numCubesZ);
        floor[numCubesX * xMap + yMap] |= FLOOR_STATUS.PLAYER;
        ExecuteEvents.Execute<FloorMessage>(target, null, (a, b) => a.getFloorInfo(floor[numCubesX * xMap + yMap]));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
