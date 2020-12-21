using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Dreadnaught_Movement : MonoBehaviour
{
    public Rigidbody rb; //define what rigidbody the movement applies to
    public float forwardForce = 100f; //force driving the rigidbody forward
    public Vector3 rotationVelocity = new Vector3 (0, 100, 0); //angular momentum used to rotate rigidbody sideways
    bool throttle;
    bool rotateRight;
    bool rotateLeft;
    int inputNum;
    float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NumberGen());
    }

    // Update is called once per frame
    void Update()
    {
        
        //Storing input using Update for use in FixedUpdate
        if (inputNum > 0)
        {
            throttle = true;
        }
        if (inputNum == 0)
        {
            throttle = false;
        } 
        
        if (inputNum == 2)
        {
            rotateRight = true;
        }

        if (inputNum == 3)
        {
            rotateLeft = true;
        }

        if (inputNum != 2)
        {
            rotateRight = false;
        }
        
        if (inputNum != 3)
        {
            rotateLeft = false;
        }

        
    }

    void FixedUpdate() //used because Unity like physics stuff in fixedupdate?
    {

        float deltaForwardForce = forwardForce * Time.deltaTime;

        if (throttle == true)
        {
            rb.AddRelativeForce(0, 0, deltaForwardForce, ForceMode.VelocityChange);
        }
        if (throttle & rotateRight == true)
        {
            Quaternion deltaRotation = Quaternion.Euler(rotationVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        if (throttle & rotateLeft == true)
        {
            Quaternion deltaRotation = Quaternion.Euler(-rotationVelocity * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
    }

    IEnumerator NumberGen() //generating numbers for random enemy behaviour
    {
        while (true)
        {
            waitTime = Random.Range(1,4);
            inputNum = Random.Range(0, 3);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
