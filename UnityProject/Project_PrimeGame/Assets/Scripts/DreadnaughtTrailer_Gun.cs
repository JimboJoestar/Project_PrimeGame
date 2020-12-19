using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadnaughtTrailer_Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 30;
    public float bulletLifeTime = 3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
        /*Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.LookAt(worldPosition);*/

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab);//instantiate bullet from prefab
        bullet.transform.position = bulletSpawn.position;
        bullet.transform.rotation = bulletSpawn.rotation;
        bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);//adds force to bullets
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeTime));
    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay) //apparently needed to destroy the bullet after some time, not very well explained in tut
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
    
}
