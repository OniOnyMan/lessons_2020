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
        var other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            CollectItem(other.GetComponent<PlayerInventory>());
        }
    }

    private void CollectItem(PlayerInventory other)
    {
        if (other.CollectItem(_itemPrefab.GetComponent<ItemContainer>()) >= 0)
        {
            Destroy(gameObject);
        }
    }
}
