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
    public float forwardSpeed;
    public float backUpSpeed;
    public float moveSpeed;
    public float jumpSpeed;
    public Sprite batIdle;
    public Sprite batHurt;
    public SpriteRenderer spriteRenderer;
    public ParticleSystem particleSystemD;
    public BatMiniGame batMiniGame;
    protected bool grounded;
    protected float persistance;
    protected BatLife batLife;
    protected bool jumping;
    protected float dir = 0;
    protected CollState collState;
    protected bool justHit;
    protected bool onlyEscape = false;

    void Awake()
    {
        batLife = GetComponent<BatLife>();
    }

    void SetUp()
    {
        batMiniGame = GameObject.FindObjectOfType<BatMiniGame>();
        spriteRenderer.sprite = batIdle;
        rigidBody2d = GetComponent<Rigidbody2D>();
        dir = 1;
        collState = CollState.Right;
        batLife.onDamage = HitDown;
        batLife.onDeath = OnDeath;

    }

    public void Launch(Vector2 power)
    {
        SetUp();
        rigidBody2d.AddForce(power, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (justHit == false)
        {
            if (rigidBody2d.velocity.magnitude < 10)
            {
                int chance = Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);
                if (chance <= 12 || onlyEscape == true)
                {
                    rigidBody2d.AddForce(new Vector2(forwardSpeed, jumpSpeed * 0.2f), ForceMode2D.Impulse);
                }
                else if(chance >= 13 && chance < 16)
                {
                    rigidBody2d.AddForce(new Vector2(backUpSpeed, jumpSpeed * Random.Range(-0.32f,0.32f)), ForceMode2D.Impulse);
                }
                else if( chance <= 16)
                {
                    rigidBody2d.AddForce(new Vector2(-10, jumpSpeed), ForceMode2D.Impulse);

                }
            }
            //CheckGround();
            //UpdateCollState();
            // JumpLogic();
        }
       
    }

    void JumpLogic()
    {
        if (grounded)
        {
            float random = Random.Range(1, 7) + Random.Range(1, 7) + Random.Range(1, 7);
            if(random < 7)
            {
                rigidBody2d.AddForce(new Vector2(0, 1) * jumpSpeed*6, ForceMode2D.Impulse);
            }
            else if(random >= 7 && random < 14) 
                    {
                rigidBody2d.AddForce(new Vector2(0.5f * dir * moveSpeed, 1*jumpSpeed*0.76f) , ForceMode2D.Impulse);
            }else{
                rigidBody2d.AddForce(new Vector2(2 * dir * moveSpeed, 0), ForceMode2D.Impulse);

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

    void HitDown()
    {
        spriteRenderer.sprite = batHurt;

        rigidBody2d.AddForce(Vector2.down * 500, ForceMode2D.Impulse);
        justHit = true;
        StartCoroutine(RestoreMovement());
        particleSystemD.Spawn(transform.position);
    }

    public void KillBat()
    {
        particleSystemD.Spawn(transform.position);
        GameObject.Destroy(gameObject);
    }

    IEnumerator RestoreMovement()
    {
        yield return new WaitForSeconds(0.8f);
        justHit = false;
        batLife.canHitAgain = true;
        spriteRenderer.sprite = batIdle;

    }

    void OnDeath()
    {
        batMiniGame.batsKilled += 1;
    }

    IEnumerator ScapeOnly()
    {
        yield return new WaitForSeconds(persistance);
        onlyEscape = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector3.down * radius);
        Gizmos.DrawRay(transform.position, Vector3.right * radius);
        Gizmos.DrawRay(transform.position, Vector3.left * radius);

    }
}
