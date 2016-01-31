using UnityEngine;
using System.Collections;

public class GameBounds : MonoBehaviour {

	void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
