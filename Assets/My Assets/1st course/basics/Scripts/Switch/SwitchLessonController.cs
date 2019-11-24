using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchLessonController : MonoBehaviour
{
    public Text HeaderText;
    public Text AnswerText;
    public InputField InputField;
    public Toggle toggle;

    public void OnCompareButtonPressed()
    {
        var tyy = toggle.isOn;

        string answer;
        int number;
        bool isParsed = int.TryParse(InputField.text, out number);

        if (isParsed)
        {
            switch (number)
            {
                case 1:
                    {
                        answer = "Январь";
                    }
                    break;
                case 2:
                    {
                        answer = "Февраль";
                    }
                    break;
                case 3:
                    {
                        answer = "Март";
                    }
                    break;
                case 4:
                    {
                        answer = "Апрель";
                    }
                    break;
                case 5:
                    {
                        answer = "Май";
                    }
                    break;
                case 6:
                    {
                        answer = "Июнь";
                    }
                    break;
                case 7:
                    {
                        answer = "Июль";
                    }
                    break;
                case 8:
                    {
                        answer = "Август";
                    }
                    break;
                case 9:
                    {
                        answer = "Сентябрь";
                    }
                    break;
                case 10:
                    {
                        answer = "Октябрь";
                    }
                    break;
                case 11:
                    {
                        answer = "Ноябрь";
                    }
                    break;
                case 12:
                    {
                        answer = "Декабрь";
                    }
                    break;
                default:
                    {
                        answer = "Не месяц";
                    }
                    break;
            }
        }
        else
        {
            answer = "Не месяц";
        }
        HeaderText.gameObject.SetActive(true);
        AnswerText.text = answer;
    }

    // Start is called before the first frame update
    void Start()
    {
        HeaderText.gameObject.SetActive(false);
        AnswerText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
