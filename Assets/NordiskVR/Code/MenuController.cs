using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] List<GameObject> sections;

    void Start()
    {
        Debug.Log(GameState.Section+" selected.");
        sections[GameState.Section].SetActive(true);
    }

}
