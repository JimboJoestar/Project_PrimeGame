using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadnaughtTrailer_Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float bulletSpeed = 5;
    public float bulletLifeTime = 5;
    private bool allowFire = true;
    public float rof = 1f;
    public bool fullAuto = false;

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

        if (Input.GetButton("Fire1") && fullAuto && allowFire)
        {
            Fire();
        }

        if (Input.GetButtonDown("Fire1") && !fullAuto && allowFire)
        {
            Fire();
        }
    }

    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);//instantiate bullet from prefab
        if (bullet.GetComponent<Rigidbody>() != null)
        {
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);//adds force to bullets, if needed
        }
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeTime));
        StartCoroutine(FireRate());

    }

    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay) //apparently needed to destroy the bullet after some time, not very well explained in tut
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }

    private IEnumerator FireRate()
    {
        allowFire = false;
        yield return new WaitForSeconds(rof);
        allowFire = true;
    }
}
