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
        var other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlayerInventory>()
                     .CollectItem(_itemPrefab.GetComponent<ItemContainer>()) >= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
