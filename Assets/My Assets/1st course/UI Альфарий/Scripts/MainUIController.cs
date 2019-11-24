using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUIController : MonoBehaviour
{
    public GameObject UpLeftBlock;
    public GameObject DownRightBlock;

    public void OnHideUpLeftPressed() 
    {
        UpLeftBlock.SetActive(!UpLeftBlock.activeInHierarchy);
    }

    public void OnHideDownRightPressed()
    {
        DownRightBlock.SetActive(!DownRightBlock.activeInHierarchy);
    }
}
