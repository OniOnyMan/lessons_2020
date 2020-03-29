using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollisionController : MonoBehaviour
{
    [SerializeField]
    private GameObject _itemPrefab;

    public GameObject ItemPrefab { get { return _itemPrefab; } }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
