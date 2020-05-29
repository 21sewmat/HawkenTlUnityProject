using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class spear : MonoBehaviour
{

    bool SpearHold = true;

  
    // Update is called once per frame
    void Update()
    {
        if (SpearHold == true && Input.GetButtonDown("Fire1"))
        {
            SpearHold = false;
            Destroy(gameObject);
        }
    }

}
