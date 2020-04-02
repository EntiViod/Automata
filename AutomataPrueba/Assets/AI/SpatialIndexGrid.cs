using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpatialIndexGrid : MonoBehaviour
{
    [SerializeField]
    int cubeWidth = 1, cubeHeight = 1, cubeDepth = 1;

    [SerializeField]
    int numCubesWidth = 5, numCubesHeight = 5, numCubesDepth = 5;

    int width, height, depth;

    [SerializeField]
    Transform[] agents;
    
    Dictionary<int ,List<Transform>> transforms;

    private void OnDrawGizmos()
    {
        
        for (int i = 0; i < numCubesHeight; i++)
            for (int j = 0; j < numCubesWidth; j++)
                for (int k = 0; k < numCubesDepth; k++)
                    Gizmos.DrawWireCube(transform.position + Vector3.up * i * cubeWidth +
                        Vector3.right * j * cubeHeight
                        + Vector3.forward * k * cubeDepth, Vector3.up * cubeHeight
                        + Vector3.right * cubeWidth +
                        Vector3.forward * cubeDepth);
    }
    // Start is called before the first frame update
    void Start()
    {
        transforms = new Dictionary<int, List<Transform>>();
        // x + numCubes * (y + depth * z)
        width = (int)transform.position.x + cubeWidth * numCubesWidth;
        height = (int)transform.position.y + cubeHeight * numCubesHeight;
        depth = (int)transform.position.z  +cubeDepth * numCubesDepth;

  
    }


    void addTransform(Vector3 pos,Transform character)
    {
        int gridx =(int)(character.position.x / width  * (width-transform.position.x) + transform.position.x);
        int gridy = (int)(character.position.y / height * (height - transform.position.y) + transform.position.y);
        int gridz = (int)(character.position.z / depth * (depth - transform.position.z) + transform.position.z);
        int index = (int)(gridx + numCubesWidth * (gridy + gridz * numCubesDepth));
        //transforms.Add(index, new List<Transform>());
        //transforms[index].Add(character);

    }

    void addTransform(int x, int y , int z, Transform character)
    {
        int index = x + numCubesWidth * (y + z * numCubesDepth);
        transforms[index].Add(character);
    }
    //max / min * (newMax -newMin) + newMin
    Transform[] getNeightbours()
    {
        return null;
    }
    
    // Update is called once per frame
    void Update()
    {
        foreach(Transform t in agents)
        {
            addTransform(t.position, t);
            
        }


    }
}
