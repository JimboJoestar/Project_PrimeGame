using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dreadnaught_GunControl_Script : MonoBehaviour
{
    public GameObject[] guns = new GameObject[3];
    private int activeGun = 0;

    private void Start()
    {
        Deactivate();
        CycleGun();
    }

    //call this before switching guns to deactivate all of them
    private void Deactivate()
    {
        foreach (GameObject gun in guns)
        {
            gun.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Activate Gun1")) 
        {
            Deactivate();
            guns[0].SetActive(true);
        }
        if (Input.GetButtonDown("Activate Gun2")) 
        {
            Deactivate();
            guns[1].SetActive(true);
        }
        if (Input.GetButtonDown("Activate Gun3")) 
        {
            Deactivate();
            guns[2].SetActive(true);
        }
        if (Input.GetButtonDown("Next Gun"))
        {
            Deactivate();
            activeGun++;
            CycleGun();
        }
        if (Input.GetButtonDown("Prev Gun"))
        {
            Deactivate();
            activeGun--;
            CycleGun();  
        }
    }

    
    private void CycleGun() 
    {
        int gunAmount = guns.Length;
        activeGun = activeGun % gunAmount;
        if (activeGun < 0)
        {
            activeGun += gunAmount;
        }
        guns[activeGun].SetActive(true);
    }
}
