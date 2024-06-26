using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameState : MonoBehaviour
{
    /// <summary>
    /// Singleton Pattern
    /// </summary>
    private static GameState _instance;
    private void Awake()
    {
        CreateSingleton();
    }

    void CreateSingleton()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    /// <summary>
    /// Members
    /// </summary>
    public static int Section { get; set; }
    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
        Debug.Log(Section + " selected.");
    }
}
