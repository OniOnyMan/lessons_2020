using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : HumanController
{
    public string[] Messages = { "Hello world!",
                                 "Ready to play",
                                 "Streaming on Twitch",
                                 "Think nothing...",
                                 "Recording a new let's play" };

    public override string GetMessage()
    {
        int indexOfMessage = Random.Range(0, Messages.Length);
        return Messages[indexOfMessage];
    }
}
