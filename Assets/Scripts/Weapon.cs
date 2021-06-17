using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firepoint;

    public GameObject bullet; 

    public void shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
}
