using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    [SerializeField] private VideoPlayer player;
    [SerializeField] private List<InterfaceAnimManager> animators;
    [SerializeField] private UnityEvent OnFinish, OnPause, OnStart;
    [SerializeField] Material matDissolve;
    private Coroutine flow;
    public void PlayVideos()
    {
        OnStart.Invoke();
        StartCoroutine(FirstAppear(animators[0], 1f));
        for (int i = 1; i<animators.Count; ++i)
        {
            var animator = animators[i];
            StartCoroutine(RandomAppear(animator, UnityEngine.Random.Range(0, 0.5f)));
        }
        flow = StartCoroutine(Pause(3.5f, 10, 5));
    }
    public void HideVideos()
    {
        foreach (var animator in animators)
        {
            StartCoroutine(RandomDisappear(animator, UnityEngine.Random.Range(0, 0.5f)));
        }
        StopCoroutine(flow);
    }
    private IEnumerator RandomAppear(InterfaceAnimManager animator, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.gameObject.GetComponent<Animator>().SetTrigger("appear");
        animator.startAppear();
    }
    private IEnumerator RandomDisappear(InterfaceAnimManager animator, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.startDisappear();
    }
    private IEnumerator FirstAppear(InterfaceAnimManager animator, float delay)
    {
        animator.startAppear();
        yield return new WaitForSeconds(delay);
        animator.gameObject.GetComponent<Animator>().SetTrigger("appear");
        yield return new WaitForSeconds(delay);
        StartCoroutine(Appear(2));
    }
    private IEnumerator Pause(float delay, float pause, float ending)
    {
        yield return new WaitForSeconds(delay);
        //player.Pause();
        OnPause.Invoke();
        yield return new WaitForSeconds(pause);
        //player.Play();
        yield return new WaitForSeconds(ending);
        OnFinish.Invoke();
        HideVideos();
    }
    public IEnumerator Appear(float time)
    {
        float t = 0;
        while (t < time)
        {
            matDissolve.SetFloat("_Dissolve", (time - t)/ time);
            t += Time.deltaTime;
            yield return null;
        }
    }
    public void ResetDissolve()
    {
        matDissolve.SetFloat("_Dissolve", 1);
    }
}
