using System;
using UnityEngine;
using UnityEngine.UI;

public class CameraSwitch : MonoBehaviour
{
    public GameObject[] objects;
    public Text text;

    private int m_CurrentActiveObject;

    private void Start()
    {
        CkeckNext();
    }

    private void OnEnable()
    {
        text.text = objects[m_CurrentActiveObject].name;
    }


    public void NextCamera()
    {
        int nextactiveobject = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;

        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].SetActive(i == nextactiveobject);
        }

        m_CurrentActiveObject = nextactiveobject;
        text.text = objects[m_CurrentActiveObject].name;

        CkeckNext();
    }

    private void CkeckNext()
    {
        var nextactiveobject2 = m_CurrentActiveObject + 1 >= objects.Length ? 0 : m_CurrentActiveObject + 1;
        for (int i = 0; i < objects.Length; i++)
        {
            if (i == nextactiveobject2)
            {
                Debug.LogWarningFormat("{0} Next {1} camera {2}" + objects[i].name, objects[i].layer, objects[i].activeInHierarchy, objects[i].activeSelf);
            }
        }
    }
}
