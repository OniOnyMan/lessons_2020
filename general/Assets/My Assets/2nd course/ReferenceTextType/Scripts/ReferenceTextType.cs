using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class A
{
    public StringBuilder NameA;
}

public class B
{
    public StringBuilder NameB;
}

public class ReferenceTextType : MonoBehaviour
{    
    public Text LeftText;
    public Text RightText;

    private StringBuilder _mainString;
    private A _aType;
    private B _bType;

    private void Start()
    {
        _mainString = new StringBuilder();
        _aType = new A() { NameA = _mainString };
        _bType = new B() { NameB = _mainString };
    }

    public void OnInputFieldValueChanged(InputField inputField)
    {
        _mainString.Remove(0, _mainString.Length);
        _mainString.Append(inputField.text);

        LeftText.text = _aType.NameA.ToString();
        RightText.text = _bType.NameB.ToString();

        //Debug.Log(_mainString.);
    }
}
