using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnaught_Movement : MonoBehaviour
{
    public Rigidbody rb; //define what rigidbody the movement applies to
    public float forwardForce = 100f; //force driving the rigidbody forward
    public Vector3 rotationVelocity = new Vector3 (0, 100, 0); //angular momentum used to rotate rigidbody sideways
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
    }

    void FixedUpdate() //used because Unity like physics stuff in fixedupdate?
    {
        //Quaternion deltaRotationRight = Quaternion.Euler(rotationVelocity*Time.deltaTime);
        //Quaternion deltaRotationLeft = Quaternion.Euler(-rotationVelocity*Time.deltaTime);
        float deltaForwardForce = forwardForce * Time.deltaTime;

        if (throttle == true)
        {
            rb.AddRelativeForce(0, 0, deltaForwardForce, ForceMode.VelocityChange);
        }
        if (throttle&rotateRight == true)
        {
            Quaternion deltaRotation = Quaternion.Euler(rotationVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);

            /*//Clamping rotation to prevent car from capsizing (DOESN'T WORK YET)
            rotationZ = rb.transform.localEulerAngles.z;
            //rotationZ = Mathf.Clamp(rotationZ, -45, 45);
            rotationX = rb.transform.localEulerAngles.x;
            //rotationX = Mathf.Clamp(rotationX, -45, 45);

            rb.transform.localEulerAngles = new Vector3(rotationX, rb.transform.localEulerAngles.y + rotationVelocity * Time.deltaTime, rotationZ);
            if (rotationX >= 45)
            {
                rb.transform.localEulerAngles = new Vector3(45, rb.transform.localEulerAngles.y + rotationVelocity * Time.deltaTime, rotationZ);
            }
            if (rotationX <= -45)
            {
                rb.transform.localEulerAngles = new Vector3(-45, rb.transform.localEulerAngles.y + rotationVelocity * Time.deltaTime, rotationZ);
            } 
            if (rotationZ >= 45)
            {
                rb.transform.localEulerAngles = new Vector3(rotationX, rb.transform.localEulerAngles.y + rotationVelocity * Time.deltaTime, 45);
            } 
            if (rotationZ <= -45)
            {
                rb.transform.localEulerAngles = new Vector3(rotationX, rb.transform.localEulerAngles.y + rotationVelocity * Time.deltaTime, -45);
            }*/
        }
        if (throttle&rotateLeft == true)
        {
            Quaternion deltaRotation = Quaternion.Euler(-rotationVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);

            /*//Clamping rotation to prevent car from capsizing (DOESN'T WORK YET)
            rotationZ = rb.transform.localEulerAngles.z;
            //rotationZ = Mathf.Clamp(rotationZ, -45, 45);
            rotationX = rb.transform.localEulerAngles.x;
            //rotationX = Mathf.Clamp(rotationX, -45, 45);

            rb.transform.localEulerAngles = new Vector3(rotationX, rb.transform.localEulerAngles.y - rotationVelocity * Time.deltaTime, rotationZ);
            if (rotationX >= 45)
            {
                rb.transform.localEulerAngles = new Vector3(45, rb.transform.localEulerAngles.y + rotationVelocity * Time.deltaTime, rotationZ);
            }
            if (rotationX <= -45)
            {
                rb.transform.localEulerAngles = new Vector3(-45, rb.transform.localEulerAngles.y + rotationVelocity * Time.deltaTime, rotationZ);
            } 
            if (rotationZ >= 45)
            {
                rb.transform.localEulerAngles = new Vector3(rotationX, rb.transform.localEulerAngles.y + rotationVelocity * Time.deltaTime, 45);
            } 
            if (rotationZ <= -45)
            {
                rb.transform.localEulerAngles = new Vector3(rotationX, rb.transform.localEulerAngles.y + rotationVelocity * Time.deltaTime, -45);
            }*/
        }
    }
}
