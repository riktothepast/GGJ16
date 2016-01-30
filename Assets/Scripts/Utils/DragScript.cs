using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour
{
    Collider2D currentCollider;
    public bool trackX, trackY;
    RaycastHit2D hit;
    float displacementSpeed;
    Vector3 lastPosition;
    public ParticleSystem ps;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                if (hit.collider.CompareTag("Draggable"))
                {
                    if (currentCollider == null)
                    {
                        currentCollider = hit.collider;
                    }
                }
            }
        }

        if (Input.GetMouseButton(0) && currentCollider)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
            currentCollider.transform.position = Vector3.Lerp(currentCollider.transform.position, new Vector3(trackX ? touchPosition.x : transform.position.x, trackY ? touchPosition.y : transform.position.y, currentCollider.transform.position.z), Time.deltaTime * 20.0f);
            displacementSpeed = (((transform.position - lastPosition).magnitude) / Time.deltaTime);
            lastPosition = transform.position;
            ps.transform.position = currentCollider.transform.position;
            ps.emissionRate = displacementSpeed;
        }
        if (Input.GetMouseButtonUp(0))
        {
            currentCollider = null;
            displacementSpeed = 0;
            ps.emissionRate = displacementSpeed;
        }
    }
}
