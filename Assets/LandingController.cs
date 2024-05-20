using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingController : MonoBehaviour
{
    [SerializeField] Material matDissolve;
    void OnEnable()
    {
        StartCoroutine(Appear());
    }
    public void SetSprite(Sprite sprite)
    {
        matDissolve.SetTexture("_BaseMap", sprite.texture);
    }
    public IEnumerator Appear()
    {
        float t = 0;
        while (t<1)
        {
            matDissolve.SetFloat("_Dissolve", 1 - t);
            t += Time.deltaTime;
            yield return null;
        }
    }
}
