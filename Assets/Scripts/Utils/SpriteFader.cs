using UnityEngine;
using System.Collections;

public class SpriteFader : MonoBehaviour {
    SpriteRenderer render;
    ObjectRecycler recycler;
    public bool useDelta;
    public float fadeStep;
	// Use this for initialization
	void OnEnable () {
        render = GetComponent<SpriteRenderer>();
        recycler = GetComponent<ObjectRecycler>();
        render.color = Color.white;
        StartCoroutine(FadeCurrentData());
	}	

    IEnumerator FadeCurrentData()
    {
        while (render.color.a > 0.1f)
        {
            render.color = Color.Lerp(render.color, Color.clear, fadeStep*Time.deltaTime);
            yield return useDelta ? new WaitForSeconds(Time.deltaTime) : null;
        }
        render.color = Color.clear;
        recycler.Recycle();
    }
}
