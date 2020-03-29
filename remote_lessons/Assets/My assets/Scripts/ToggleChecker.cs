using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleChecker : MonoBehaviour
{
    public Text Output;

    public void OnCheckButtonPressed()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var temp = transform.GetChild(i);
            if (temp.GetComponent<Toggle>().isOn)
            {
                Output.text = temp.name;
                break;
            }
        }
    }
}
