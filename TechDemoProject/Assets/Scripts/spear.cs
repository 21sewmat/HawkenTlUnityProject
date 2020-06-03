using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class spear : MonoBehaviour
{
    public float offset;
    bool SpearHold = true;
    public Transform shotPoint;
    public GameObject projectile;

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
        if (SpearHold == true)
        {
            if (Input.GetButtonDown("Fire1") && SpearHold == true)
            {
                Instantiate(projectile, shotPoint.position, transform.rotation);
                SpearHold = false;
                Destroy(gameObject);
            }
        }
    }
}