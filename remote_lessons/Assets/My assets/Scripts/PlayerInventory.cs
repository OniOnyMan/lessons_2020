using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public float RayDistance = 5f;
    public LayerMask layerMask;
    public Transform HeadCamera;

    private ItemContainer[] _inventory = new ItemContainer[9];
    private int _selectedItem = 0;

    void Start()
    {

    }

    void Update()
    {
        Debug.DrawRay(HeadCamera.position, HeadCamera.forward * RayDistance, Color.yellow);
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickUpItem();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropSelectedItem();
        }

        var scrollY = Input.mouseScrollDelta.y;
        if (scrollY != 0)
        {
            CheckScroll(scrollY);
        }
    }

    private void DropSelectedItem()
    {
        if (_inventory[_selectedItem])
        {
            InverntoryPanelController.DropItem(_selectedItem);
            var dropPos = transform.Find("DropPoint").position;
            var prefab = _inventory[_selectedItem].ScenePrefab;
            Instantiate(prefab, dropPos, Quaternion.identity);
            Debug.Log(_inventory[_selectedItem].GetComponent<Collider>());

            _inventory[_selectedItem] = null;
        }
    }

    private void TryPickUpItem()
    {
        RaycastHit hit;
        Ray ray = HeadCamera.GetComponent<Camera>()
                            .ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));

        if (Physics.Raycast(ray, out hit, RayDistance, layerMask))
        {
            Debug.Log(hit.transform.name);
            if (hit.transform.gameObject.CompareTag("PickedUp"))
            {
                if (CollectItem(hit.transform.GetComponent<ItemCollisionController>()
                                   .ItemPrefab.GetComponent<ItemContainer>()) >= 0)
                {
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    private void FixedUpdate()
    {
        
    }

    private void CheckScroll(float scrollY)
    {
        var newSelectedItem = _selectedItem + (scrollY < 0 ? 1 : -1);

        if (newSelectedItem < 0)
            _selectedItem = _inventory.Length - 1;
        else if (newSelectedItem >= _inventory.Length)
            _selectedItem = 0;
        else
            _selectedItem = newSelectedItem;

        InverntoryPanelController.SelectContainer(_selectedItem);
    }

    public int CollectItem(ItemContainer item) 
    {
        int lastEmpty = -1;
        for (int i = 0; i < _inventory.Length; i++)
        {
            if (_inventory[i] == null)
            {
                _inventory[i] = item;
                lastEmpty = i;
                break;
            }
        }

        if (lastEmpty >= 0)
        {
            InverntoryPanelController.ShowItem(lastEmpty, item);
        }

        return lastEmpty;
    }
}
