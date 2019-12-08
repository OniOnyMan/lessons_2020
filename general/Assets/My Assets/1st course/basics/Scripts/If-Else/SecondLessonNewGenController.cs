using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondLessonNewGenController : MonoBehaviour
{
    public InputField TaskInputField;
    public InputField ResearchedInputField;

    [SerializeField]
    private Text _answerText;

    public void OnSolveButtonPressed()
    {
        float taskValue, researchValue;
        var taskParse = float.TryParse(TaskInputField.text.Replace('.', ','), out taskValue);
        var researchParse = float.TryParse(ResearchedInputField.text.Replace('.', ','), out researchValue);


        if (!taskParse || !researchParse)
        {
            _answerText.text = "Не число";
            return;
        }
        if (taskValue == researchValue)
        {
            _answerText.text = "Равны";
        }
        else
        {
            if (taskValue > researchValue)
            {
                _answerText.text = "Меньше";
            }
            else
            {
                _answerText.text = "Больше";
            }
        }
    }

    private void Awake()
    {
        _answerText = GameObject.FindGameObjectWithTag("AnswerBody1").GetComponent<Text>();
        //_answerText = GameObject.Find("Body").GetComponent<Text>();
    }
}
