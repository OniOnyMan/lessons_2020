using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSwitch : MonoBehaviour
{
    public Sprite Opened;
    public Sprite Closed;
    public bool IsClosed;

    private Image _image;    

    private void Start() 
    {
        _image = GetComponent<Image>();
        SetSprite();
    }

    public void OnSwiched() 
    {
        IsClosed = !IsClosed;
        SetSprite();
    }

    private void SetSprite() 
    {
        _image.sprite = IsClosed ? Closed : Opened;
    }
}
