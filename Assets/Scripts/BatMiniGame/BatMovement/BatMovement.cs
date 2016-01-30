using UnityEngine;
using System.Collections;

public enum CollState
{
    Right,
    Left,
    None
}

public class BatMovement : MonoBehaviour {

    public Rigidbody2D rigidBody2d;
    public LayerMask layerMask;
    public float radius;
    protected bool grounded;
    protected bool jumping;
    protected float dir = 0;
    protected CollState collState;
    void Start()
    {
        TimeClassManager.StartTimer(3, JumpLogic);
        rigidBody2d = GetComponent<Rigidbody2D>();
        dir = 1;
        collState = CollState.Right;
    }

    void Update()
    {
        CheckGround();
        UpdateCollState();
        JumpLogic();
    }

    void JumpLogic()
    {
        if (grounded)
        {
            float random = Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);
            if(random < 5)
            {
                rigidBody2d.AddForce(new Vector2(0, 1) * 10, ForceMode2D.Impulse);
            }
            else {
                rigidBody2d.AddForce(new Vector2(0.5f * dir, 1) * 7, ForceMode2D.Impulse);
            }
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

    void UpdateCollState()
    {
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector3.right, radius, layerMask);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector3.left, radius, layerMask);
        if(hitRight.collider != null)
        {
            dir = -1;
            collState = CollState.Right;
        }
        else if(hitLeft.collider != null)
        {
            collState = CollState.Left;
            dir = 1;
        }
        else
        {
            collState = CollState.None;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down * radius);
        Gizmos.DrawRay(transform.position, Vector3.right * radius);
        Gizmos.DrawRay(transform.position, Vector3.left * radius);

    }
}
