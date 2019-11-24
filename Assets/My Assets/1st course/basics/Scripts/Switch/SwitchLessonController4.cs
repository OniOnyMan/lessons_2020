using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SwitchLessonController4 : MonoBehaviour
{
    public Toggle toggle;

    public Text Header;
    public Text Answer;
    public InputField InputField;

    private enum GraphicSettings {
        Minimum, Deafult, Middle, High
    }

    private void DoNothing(GraphicSettings settings)
    {
        var condition = toggle.isOn;

        switch (settings)
        {
            case GraphicSettings.Minimum:
                {
                }
                break;
            case GraphicSettings.Deafult:
                break;
            case GraphicSettings.Middle:
                break;
            case GraphicSettings.High:
                break;
            default:
                break;
        }
    }

    public void OnButtonPressed()
    {
        int number;
        bool isParse = int.TryParse(InputField.text, out number);
        string answer;

        if (isParse)
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
                        answer = "Не номер месяца";
                    }
                    break;
            }
        }
        else
        {
            answer = "Не число";
        }

        Header.gameObject.SetActive(true);
        Answer.text = answer;
    }

    private void Start()
    {
        Header.gameObject.SetActive(false);
        Answer.text = "";
    }
}

