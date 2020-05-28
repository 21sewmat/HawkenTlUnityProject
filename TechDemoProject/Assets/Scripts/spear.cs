using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class spear : MonoBehaviour
{
    public float Damage = 10;
    public LayerMask notToHit;
    bool SpearHold = true;

    Transform firePoint;
    

    // Start is called before the first frame update
    void Start()
    {
        firePoint = transform.Find("FirePoint");
    }

    // Update is called once per frame
    void Update()
    {
        if (SpearHold == true && Input.GetButtonDown("Fire1"))
        {
            Shoot();   
        }
    }

    void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition = firePointPosition, 100, notToHit);
        SpearHold = false;
    }
}
