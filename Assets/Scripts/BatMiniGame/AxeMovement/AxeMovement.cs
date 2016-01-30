using UnityEngine;
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
    public Transform safeZone;
    protected bool canHit = true;
    protected bool isHitting = false;
    public SpriteRenderer AxeRenderer;
    public SpriteRenderer TriggerRenderer;


    void Awake()
    {
        Cursor.visible = false;
        isHitting = false;
        AxeRenderer = GetComponentInChildren<SpriteRenderer>();
    }

	void Update()
    {
        if(transform.position.y < safeZone.position.y)
        {
            canHit = false;
            AxeRenderer.color = Color.gray;
            TriggerRenderer.color = Color.gray;
        }
        else
        {
            canHit = true;
            AxeRenderer.color = Color.white;
            TriggerRenderer.color = Color.white;
        }

        if (Input.GetMouseButtonDown(0) && isHitting == false && canHit == true)
        {
            //hit
            AxeRenderer.sprite = hit;
            isHitting = true;
            StartCoroutine(ReturnToIdle());
        }
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
        Vector3 coordiantes = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = coordiantes+ Vector3.forward *40;
    }

    IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(0.18f);
        AxeRenderer.sprite = idle;
        isHitting = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPosition.position, hitRadius);
    }
}
