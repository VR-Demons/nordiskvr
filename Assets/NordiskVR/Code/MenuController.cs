using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] List<GameObject> sections;

    void Start()
    {
        StartUI();
    }

    public void StartUI()
    {
        sections[GameState.Section].SetActive(true);
        InterfaceAnimManager[] managers = sections[GameState.Section].GetComponentsInChildren<InterfaceAnimManager>();
        foreach (InterfaceAnimManager manager in managers)
        {
            manager.startAppear();
        }
        Debug.Log(GameState.Section + " selected, "+ managers.Length+" sections.");
    }
}
