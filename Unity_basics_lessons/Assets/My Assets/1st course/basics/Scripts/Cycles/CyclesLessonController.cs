using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CyclesLessonController : MonoBehaviour
{
    public InputField InputText;
    public Toggle IsLeap;
    public Text AnswerText;
    public ToggleGroup CyclesToggles;

    public void OnSolveButtonPressed()
    {
        int dayNumber;
        bool isParsed = int.TryParse(InputText.text, out dayNumber);

        if (isParsed)
        {
            var mouthName = GetMouthName(CalculateMonthNumber(ref dayNumber));
            AnswerText.text = string.Format("{0}, {1}", dayNumber.ToString(), mouthName.ToLower());
        }
        else
        {
            AnswerText.text = "Введено некорректное значение";
        }
    }

    private string GetMouthName(int mounthNumber)
    {
        string answer;
        switch (mounthNumber)
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
        return answer;
    }

    private int CalculateMonthNumber(ref int dayNumber)
    {
        bool isDivided = true;
        int mounthNumber = 1;
        if (dayNumber > 0 && dayNumber <= (IsLeap.isOn ? 366 : 365))
        {
            do
            {
                var dayCount = GetCountOfMounthDays(mounthNumber);
                if (dayNumber <= dayCount)
                {
                    isDivided = false;
                }
                else
                {
                    dayNumber -= dayCount;
                    mounthNumber = mounthNumber == 12 ? 1 : mounthNumber + 1;
                }
            }
            while (isDivided);

            return mounthNumber;
        }
        return -1;
    }

    private int GetCountOfMounthDays(int monthNumber)
    {
        switch (monthNumber)
        {
            case 1:
                {
                    return 31;
                }
            case 2:
                {
                    if (IsLeap.isOn)
                    {
                        return 29;
                    }
                    return 28;
                }
            case 3:
                {
                    return 31;
                }
            case 4:
                {
                    return 30;
                }
            case 5:
                {
                    return 31;
                }
            case 6:
                {
                    return 30;
                }
            case 7:
                {
                    return 31;
                }
            case 8:
                {
                    return 31;
                }
            case 9:
                {
                    return 30;
                }
            case 10:
                {
                    return 31;
                }
            case 11:
                {
                    return 30;
                }
            case 12:
                {
                    return 31;
                }
            default:
                {
                    return -1;
                }
        }
    }
}
