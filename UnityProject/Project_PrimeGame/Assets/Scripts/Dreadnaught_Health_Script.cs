using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnaught_Health_Script : MonoBehaviour
{
    public float health = 100f;
    private GameObject meshWhole;
    private GameObject meshDestroyed;
    private Dreadnaught_Death_Script DeathScript;
    
    // Start is called before the first frame update
    void Start()
    {
        meshWhole = gameObject.transform.Find("Mesh").gameObject;
        meshDestroyed = gameObject.transform.Find("MeshDest").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        print("hit" + other.name);
        if (other.tag == "Bullet")
        {
            health = health - other.gameObject.GetComponent<BulletBehaviour>().damage;
            Die();
        }
    }

    private void Die()//check for death state, call after every damage event
    {
        if (health <= 0)
        {
            meshWhole.SetActive(false);
            meshDestroyed.SetActive(true);
            DeathScript = gameObject.GetComponentInParent<Dreadnaught_Death_Script>();
            DeathScript.dreadnaughtDeath();
        }
    }
}
