using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float damage = 10;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
