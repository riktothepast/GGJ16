using UnityEngine;
using System.Collections;

public class AxeMovement : MonoBehaviour {

    public Sprite idle;
    public Sprite hit;

    protected bool isHitting = false;
    protected SpriteRenderer spriteRenderer;

    void Awake()
    {
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
        }

        Vector3 coordiantes = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = coordiantes+ Vector3.forward *40;
    }

    IEnumerator ReturnToIdle()
    {
        yield return new WaitForSeconds(1.2f);
        spriteRenderer.sprite = idle;
        isHitting = false;
    }
}
