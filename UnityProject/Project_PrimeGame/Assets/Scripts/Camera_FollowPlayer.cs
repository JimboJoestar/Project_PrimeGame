using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour
{

    public Transform player;
    private Vector3 positionOffset;
    public float scrollSens = 0.1f; //used to offset zoom speed based on scroll sensitivity
    private float scrollDelta;
    public float zoom = 50f;
    public float rotSens = 1; // used to determine how sensitive camera rotation is
    private float yaw;
    private float pitch = 90;

    // Update is called once per frame
    void Update()
    {
        //print(Input.mouseScrollDelta);
        scrollDelta = -Input.mouseScrollDelta.y * scrollSens;
        zoom = zoom + scrollDelta;
        positionOffset = new Vector3(0, zoom, 0);
        
        transform.position = player.position + positionOffset;

        //print (Input.GetAxis("Mouse X"));
        if (Input.GetButton("Fire2") == true)
        {
            yaw += Input.GetAxis("Mouse X") * rotSens;
            pitch -= Input.GetAxis("Mouse Y") * rotSens;

            transform.eulerAngles = new Vector3 (pitch, yaw, 0f);
        }

    }
}