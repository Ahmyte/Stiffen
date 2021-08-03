using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffEffectTimer : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 200);
        StartCoroutine(Waiting2());
    }

    IEnumerator Waiting2()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 150);
        StartCoroutine(Waiting3());
    }

    IEnumerator Waiting3()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 90);
        StartCoroutine(Waiting4());
    }
    IEnumerator Waiting4()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(0, 255, 255, 30);
        Destroy(gameObject);
    }
}
