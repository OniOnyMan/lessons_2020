using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InverntoryPanelController : MonoBehaviour
{
    private static InverntoryPanelController _instance;

    public static InverntoryPanelController Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = GameObject.FindGameObjectWithTag("InventoryPanel")
                                      .GetComponent<InverntoryPanelController>();
            }
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

    private static int _selectedItem = 0;

    public Color MainColor;
    public Color SelectedColor;

    void Start()
    {
        SelectContainer(0);
    }

    void Update()
    {
        
    }

    public static void SelectContainer(int index) 
    {
        var current = Instance.transform.GetChild(index).GetComponent<Image>();
        current.color = Instance.SelectedColor;
        if (index != _selectedItem)
        {
            var previous = Instance.transform.GetChild(_selectedItem).GetComponent<Image>();
            previous.color = Instance.MainColor;
            _selectedItem = index;
        }
    }

    public static void ShowItem(int index, ItemContainer item) 
    {
        var container =  Instance.transform.GetChild(index);
        var icon = container.Find("Image").GetComponent<Image>();
        icon.sprite = item.Icon;
        icon.color = Color.white;
    }

    public static void DropItem(int index) 
    {
        var container = Instance.transform.GetChild(index);
        var icon = container.Find("Image").GetComponent<Image>();
        icon.sprite = null;
        icon.color = Color.clear;
    }
}
