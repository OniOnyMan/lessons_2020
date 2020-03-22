﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public float RayDistance = 5f;
    public LayerMask layerMask;
    public Transform HeadCamera;
    [Space]
    public GameObject[] Inventory;

    private List<GameObject> _inventory = new List<GameObject>();

    void Start()
    {
        
    }

    void Update()
    {
        //Debug.DrawRay(HeadCamera.position, HeadCamera.forward * int.MaxValue, Color.yellow);
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            RaycastHit hit;
            Ray ray = HeadCamera.GetComponent<Camera>().ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            if (Physics.Raycast(ray, out hit, layerMask)) 
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.gameObject.CompareTag("Gold"))
                {
                    _inventory.Add(hit.transform.gameObject);
                    Inventory = _inventory.ToArray();
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }


}