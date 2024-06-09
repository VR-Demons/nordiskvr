using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LandingController : MonoBehaviour
{
    [SerializeField] Material matDissolve;
    [SerializeField] List<Image> SpriteList;
    [SerializeField] List<Image> SpriteWireList;
    [SerializeField] List<Image> SpriteTintList;
    void OnEnable()
    {
        StartCoroutine(Appear());
    }
    public void SetSprite(Sprite sprite)
    {
        matDissolve.SetTexture("_BaseMap", sprite.texture);
        foreach (Image image in SpriteList)
        {
            image.sprite = sprite;
            image.preserveAspect = true;
        }
    }
    public void SetSpriteWire(Sprite sprite)
    {
        foreach (Image image in SpriteWireList)
        {
            image.sprite = sprite;
            image.preserveAspect = true;
        }
    }
    public void SetSpriteTint(Sprite sprite)
    {
        foreach (Image image in SpriteTintList)
        {
            image.sprite = sprite;
            image.preserveAspect = true;
        }
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
