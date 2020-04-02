using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGolem : MonoBehaviour, FloorMessage
{
    public void getFloorInfo(SpatialIndex.FLOOR_STATUS state)
    {
        if(CharacterMove.checkWithFloor((int)state,(int)SpatialIndex.FLOOR_STATUS.LAVA))
        {
            transform.localScale += Vector3.one * Time.deltaTime;
        }
        if (CharacterMove.checkWithFloor((int)state, (int)SpatialIndex.FLOOR_STATUS.WATER))
        {
            transform.localScale -= Vector3.one * Time.deltaTime;
        }
    }

    [SerializeField]
    SpatialIndex spatial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spatial.getFloorState(transform.position.x, transform.position.z, gameObject);
    }
}
