using UnityEngine;
using InControl;
using System.Collections;

public class AxeMovement : MonoBehaviour {

    public Sprite idle;
    public Sprite hit;
    public Sprite triggerOff;
    public Sprite triggerOn;
    public Sprite ready;
    public float hitRadius;
    public LayerMask mask;
    public Transform hitPosition;
    protected bool canHit = true;
    protected bool isHitting = false;
    public SpriteRenderer AxeRenderer;
    public SpriteRenderer TriggerRenderer;
    public MovementController move;
    public GameBounds gameBounds;
    public Vector3 velocity;
    public float speed;

    void Awake()
    {
        Cursor.visible = false;
        isHitting = false;
        AxeRenderer = GetComponentInChildren<SpriteRenderer>();
        move = MovementController.CreateWithDefaultBindings();
    }

	void Update()
    {
        AxeClick();
        if(isHitting == true)
        {
            RaycastHit2D hit = Physics2D.CircleCast(hitPosition.position, hitRadius, Vector2.zero, 0,mask);
            if(hit.collider != null)
            {
                BatLife batLife = hit.collider.GetComponent<BatLife>();
                if(batLife != null)
                {
                    batLife.ListenForHit(hitPosition.position);
                }
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.CircleCast(hitPosition.position, hitRadius, Vector2.zero, 0,mask);
            if (hit.collider != null)
            {
                float distnace = Vector3.Distance(hitPosition.position, hit.collider.transform.position);
                AxeRenderer.sprite = ready;
                TriggerRenderer.sprite = triggerOn;
            }
            else
            {
                AxeRenderer.sprite = idle;
                TriggerRenderer.sprite = triggerOff;

            }
        }

        ControllerMovement();
      
    }

    public void AxeClick()
    {
        if(move.AButton.WasPressed && isHitting == false && canHit == true)
        {
            //hit
            AxeRenderer.sprite = hit;
            isHitting = true;
            canHit = false;
            StartCoroutine(ReturnToIdle());
        }
    }

    public void ControllerMovement()
    {

        velocity.x = move.Move.X;


        velocity.y = move.Move.Y;

        if(velocity.magnitude > 1)
        {
            velocity = velocity.normalized;
        }
        Vector3 newPOs = transform.position + velocity * speed * Time.deltaTime;
        if(!(newPOs.x < gameBounds.transform.position.x + gameBounds.transform.localScale.x*0.5f && newPOs.x > gameBounds.transform.position.x - gameBounds.transform.localScale.x * 0.5f))
        {
            newPOs.x = transform.position.x;
        }
        if (!(newPOs.y < gameBounds.transform.position.y + gameBounds.transform.localScale.y * 0.5f && newPOs.y > gameBounds.transform.position.y - gameBounds.transform.localScale.y * 0.5f))
        {
            newPOs.y = transform.position.y;
        }
        transform.position = newPOs;
    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0) && isHitting == false && canHit == true)
        {
            //hit
            AxeRenderer.sprite = hit;
            isHitting = true;
            canHit = false;
            StartCoroutine(ReturnToIdle());
        }
    }

    public void MouseMovement()
    {
        Vector3 coordiantes = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = coordiantes + Vector3.forward * 40;
    }

    IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(0.18f);
        AxeRenderer.sprite = idle;
        isHitting = false;
        canHit = true;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPosition.position, hitRadius);
    }
}
