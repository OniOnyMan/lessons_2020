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

        if (Input.GetKeyDown(KeyCode.Q)) 
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
    }

    private void FixedUpdate()
    {
        var currentSelectedItem = _selectedItem;

        var scrollY = Input.mouseScrollDelta.y;
        if (scrollY != 0)
        {
            _selectedItem -= (int)scrollY;

            //Debug.Log("До математики " + _selectedItem);
            //TO DO: количество строк из среды
            _selectedItem = Mathf.Abs(_selectedItem) % _inventory.Length;
           // Debug.Log("После математики " + _selectedItem);

            if (currentSelectedItem != _selectedItem)
            {
                InverntoryPanelController.SelectContainer(_selectedItem);
            }
        }
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
