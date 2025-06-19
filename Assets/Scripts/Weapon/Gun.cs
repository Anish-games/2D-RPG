using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gun : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bullet;


 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet , firePoint.position ,firePoint.rotation);
    }
}
