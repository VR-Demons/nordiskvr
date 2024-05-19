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
    [SerializeField] private UnityEvent OnFinish;
    public void PlayVideos()
    {
        foreach (var animator in animators)
        {
            animator.startAppear();
        }
        StartCoroutine(Pause(3, 10, 5));
    }
    public void HideVideos()
    {
        foreach (var animator in animators)
        {
            animator.startDisappear();
        }
    }

    private IEnumerator Pause(float delay, float pause, float ending)
    {
        yield return new WaitForSeconds(delay);
        player.Pause();
        yield return new WaitForSeconds(pause);
        player.Play();
        yield return new WaitForSeconds(ending);
        HideVideos();
        OnFinish.Invoke();
    }
}
