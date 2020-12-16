using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 positionOffset;
    public Quaternion rotationOffset;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + positionOffset;
        // transform.rotation = player.rotation * rotationOffset;
    }
}