using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHideSwitch : MonoBehaviour
{
    public Sprite Opened;
    public Sprite Closed;
    public bool IsClosed;

    private Image _image;    

    private void Start() 
    {
        _image = transform.GetChild(0).GetComponent<Image>();
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
