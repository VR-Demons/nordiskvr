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
    [SerializeField] private UnityEvent OnFinish, OnPause;
    private Coroutine flow;
    public void PlayVideos()
    {
        foreach (var animator in animators)
        {
            animator.startAppear();
        }
        flow = StartCoroutine(Pause(3.5f, 10, 5));
    }
    public void HideVideos()
    {
        foreach (var animator in animators)
        {
            animator.startDisappear();
        }
        StopCoroutine(flow);
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
}
