using UnityEngine;
using System.Collections;

public class AxeMovement : MonoBehaviour {

    public Sprite idle;
    public Sprite hit;
    public float hitRadius;
    public Transform hitPosition;
    protected bool isHitting = false;
    protected SpriteRenderer spriteRenderer;

    void Awake()
    {
        Cursor.visible = false;
        isHitting = false;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

	void Update()
    {
        if(Input.GetMouseButtonDown(0) && isHitting == false)
        {
            //hit
            spriteRenderer.sprite = hit;
            isHitting = true;
            StartCoroutine(ReturnToIdle());
        }
        if(isHitting == true)
        {
            RaycastHit2D hit = Physics2D.CircleCast(hitPosition.position, hitRadius, Vector2.zero, 0);
            if(hit.collider != null)
            {
                Debug.Log("Hit");
            }
        }
        Vector3 coordiantes = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = coordiantes+ Vector3.forward *40;
    }

    IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(0.09f);
        spriteRenderer.sprite = idle;
        isHitting = false;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitPosition.position, hitRadius);
    }
}
