using UnityEngine;
using System.Collections;

public class AngelAdjuster : MonoBehaviour {

    public GameObject angleTo;

    void Update()
    {
        float angle = Mathf.Atan2((angleTo.transform.position.y - transform.position.y) , (angleTo.transform.position.x - transform.position.x));
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg*angle-90);
    }
}
