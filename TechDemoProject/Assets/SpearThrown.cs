using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class SpearThrown : MonoBehaviour
{
    public enum Stick { t, f };
    Stick IsStuck;
    public GameObject projectile;
    private Collider2D coll;
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask player;
    public Vector2 velocity;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    private enum SpearState { motion, stick }
    private SpearState state = SpearState.motion;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        IsStuck = Stick.f;

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x > 0 && IsStuck == Stick.f)
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (rb.velocity.x < 0 && IsStuck == Stick.f)
        {
            transform.localScale = new Vector2(-1, 1);
        }

        if (coll.IsTouchingLayers(ground))
        {
            IsStuck = Stick.t;
        }
        if (IsStuck == Stick.t)
        {
            rb.velocity = new Vector2 (0, 0);
            rb.isKinematic = true;
            rb.gravityScale = 0;
        }

        if (coll.IsTouchingLayers(player) && IsStuck == Stick.t)
        {
            Destroy(gameObject);
        }
    }
}
