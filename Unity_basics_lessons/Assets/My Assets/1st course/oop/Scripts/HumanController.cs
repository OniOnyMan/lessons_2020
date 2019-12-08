using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HumanController : MonoBehaviour {

    private enum MessageState
    {
        ReadyToShow, ReadyToDisable
    }

    public float MessageCoolDown = 5;

    private TextMesh _upheadText;
    private float _timer;
    private MessageState _messageState = MessageState.ReadyToShow;

    private void Start()
    {
        _upheadText = transform.Find("Text").GetComponent<TextMesh>();
        _timer = MessageCoolDown;
        DisableMessage();
    }

    void Update ()
    {
        if (_timer > 0)
        {
            _timer -= Time.deltaTime;
        }
        else
        {
            if (_messageState == MessageState.ReadyToShow)
            {
                SayMessage();
                _messageState = MessageState.ReadyToDisable;
            }
            else
            {
                DisableMessage();
                _messageState = MessageState.ReadyToShow;
            }

            _timer = MessageCoolDown;
        }
	}

    public void SayMessage()
    {
        _upheadText.text = GetMessage();
    }

    public abstract string GetMessage();

    public void DisableMessage()
    {
        _upheadText.text = "";
    }
}
