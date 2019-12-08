using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIToggleSpawner : MonoBehaviour
{
    public ToggleSwitch Switcher;
    public GameObject LeftToggleUIPrefab;
    public GameObject RightToggleUIPrefab;

    private GameObject _currentUI;

    public void Start()
    {
        SpawnUI();
    }

    public void SpawnUI() 
    {
        Destroy(_currentUI);
        _currentUI = Instantiate(Switcher.IsClosed ? RightToggleUIPrefab : LeftToggleUIPrefab);
    }
}
