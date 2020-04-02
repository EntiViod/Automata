using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class CharacterMove : MonoBehaviour, IEntity, FloorMessage
{
    
    public static bool checkWithFloor(int mask, int maskToCompare)
    {
        return (mask & maskToCompare) == maskToCompare;
    }

[SerializeField]
    CharacterController controller;
    [SerializeField]
    public float speed = 12f;
    [SerializeField]
    bool flyMode = false;

    public float jumpHeight = 3.0f;

    Vector3 velocity;
    bool isGrounded;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField]
    SpatialIndex spatial;

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundDistance);

    }

    void IEntity.EAwake()
    {

    }

   

    void IEntity.EUpdate(float delta)
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;

           spatial.getFloorState(transform.position.x, transform.position.z, gameObject);


        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);
        }
        if (!flyMode)
        {
            velocity += Physics.gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

       

    }

    IEnumerator onFire(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

    public void getFloorInfo(SpatialIndex.FLOOR_STATUS state)
    {
        


        if (checkWithFloor((int)state, (int)SpatialIndex.FLOOR_STATUS.WATER))
        {
            speed = 6.0f;
        }
        else if(checkWithFloor((int)state, (int)SpatialIndex.FLOOR_STATUS.LAVA))
        {
            speed = 6.0f;
            Debug.Log("AHHH");
            controller.Move(Vector3.up * 50.0f * Time.deltaTime);
        }
        else
        {
            speed = 12.0f;
        }
    }
}



