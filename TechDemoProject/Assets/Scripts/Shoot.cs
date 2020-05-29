using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public enum SpearHold { t , f };
    SpearHold IsSpearHeld;
    public GameObject projectile;
    public GameObject SpearHoldObj;
    public GameObject parent;
    public Vector2 velocity;
    public Vector2 offset = new Vector2 (0.4f,0.1f);
    public Vector2 SpearHoldOffset = new Vector2(0, -0.45f);
    private Collider2D coll;
    [SerializeField] private LayerMask spear;



    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        IsSpearHeld = SpearHold.t;


    }

    // Update is called once per frame
    void Update()
    {
        if (IsSpearHeld == SpearHold.t && Input.GetButtonDown("Fire1"))
        {
            IsSpearHeld = SpearHold.f;
            GameObject goProj = (GameObject)Instantiate(projectile, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);
            goProj.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);
        }

        if (coll.IsTouchingLayers(spear))
        {
            IsSpearHeld = SpearHold.t;
            GameObject goSpHd = (GameObject)Instantiate(SpearHoldObj, (Vector2)transform.position + SpearHoldOffset * transform.localScale.x, Quaternion.identity);
            goSpHd.transform.parent = parent.transform;
        }
    }
}
