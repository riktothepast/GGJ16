using UnityEngine;
using System.Collections;

public enum CollState
{
    Right,
    Left
}

public class BatMovement : MonoBehaviour {

    public Rigidbody2D rigidBody2d;
    public LayerMask layerMask;
    public float radius;
    protected bool grounded;
    protected bool jumping;

    void Start()
    {
        TimeClassManager.StartTimer(3, JumpLogic);
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        CheckGround();
        JumpLogic();
    }

    void JumpLogic()
    {
        if (grounded)
        {
            rigidBody2d.AddForce(new Vector2(0.5f, 1) * 7, ForceMode2D.Impulse);
        }
    }

    void CheckGround()
    {
        RaycastHit2D below = Physics2D.Raycast(transform.position, Vector3.down, radius, layerMask);
        if(below.collider != null)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down * radius);
    }
}
