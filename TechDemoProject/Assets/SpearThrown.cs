using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class SpearThrown : MonoBehaviour
{

    [SerializeField] private LayerMask Ground;
    [SerializeField] private LayerMask player;
    public Vector2 velocity;
    public float speed;
    private Rigidbody2D rb;
    private Collider2D coll;
    Color rayColor;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (coll.IsTouchingLayers(Ground))
        {
            transform.Translate(Vector2.right * 0 * 0);
            rb.isKinematic = true;
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
            
    }

    private bool IsGrounded()
    {
        float extraHeightText = 0.1f;

        RaycastHit2D raycastHit = Physics2D.Raycast(transform.position, Vector2.right, extraHeightText, Ground);

        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
            Debug.Log("Hit");
            transform.Translate(Vector2.right * speed * 0);
        }
        else
        {
            rayColor = Color.red;
        }
        Debug.DrawRay(coll.bounds.center, Vector2.right * (extraHeightText), rayColor);
        Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
}