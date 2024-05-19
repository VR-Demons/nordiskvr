using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TunnelController : MonoBehaviour
{
    [SerializeField] float Delay;
    [SerializeField] int SceneIndex;
    void Start()
    {
        StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(Delay);
        SceneManager.LoadScene(SceneIndex);
    }
}
