using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnaught_Movement : MonoBehaviour
{
    public Rigidbody rb; //define what rigidbody the movement applies to
    public float forwardForce = 100f; //force driving the rigidbody forward
    public Vector3 rotationVelocity = new Vector3(0, 100, 0); //force used to push rigidbody sideways
    bool throttle;
    bool rotateRight;
    bool rotateLeft;
    //private float rotationZ = 0;
    //private float rotationX = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Storing input using Update for use in FixedUpdate
        if (Input.GetKeyDown("w"))
        {
            throttle = true;
        }
        if (Input.GetKeyUp("w"))
        {
            throttle = false;
        } 
        
        if (Input.GetKeyDown("d"))
        {
            rotateRight = true;
        }
        if (Input.GetKeyUp("d"))
        {
            rotateRight = false;
        }

        if (Input.GetKeyDown("a"))
        {
            rotateLeft = true;
        }
        if (Input.GetKeyUp("a"))
        {
            rotateLeft = false;
        }


        //Clamping rotation to prevent car from capsizing
        //rotationZ += rb.rotation; 

    }

    void FixedUpdate() //used because Unity like physics stuff in fixedupdate?
    {
        Quaternion deltaRotationRight = Quaternion.Euler(rotationVelocity*Time.deltaTime);
        Quaternion deltaRotationLeft = Quaternion.Euler(-rotationVelocity*Time.deltaTime);
        float deltaForwardForce = forwardForce * Time.deltaTime;

        if (throttle == true)
        {
            rb.AddRelativeForce(0, 0, deltaForwardForce, ForceMode.VelocityChange);
        }
        if (throttle&rotateRight == true)
        {
            rb.MoveRotation(rb.rotation*deltaRotationRight);
        }
        if (throttle&rotateLeft == true)
        {
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }
    }
}
