using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondLessonController : MonoBehaviour
{
    public Text Task;
    public InputField TaskInputField;
    public InputField RequestedInputField;

    private Text _answerBody;

    public void CompareButtonPressed()
    {
        float taskValue, requestedValue;
        var taskParse = float.TryParse(TaskInputField.text.Replace('.', ','), out taskValue);
        var requestedParse = float.TryParse(RequestedInputField.text.Replace('.', ','), out requestedValue);

        if (!taskParse || !requestedParse)
        {
            _answerBody.text = "Не число.";
            return;
        }

        if (taskValue == requestedValue)
        {
            _answerBody.text = "Равны.";
        }
        else
        {
            if (taskValue > requestedValue)
            {
                _answerBody.text = "Меньше.";
            }
            else
            {
                _answerBody.text = "Больше.";
            }
        }

        var taskObj = Task.gameObject;
        taskObj.SetActive(!taskObj.activeInHierarchy);

        if (taskObj.activeInHierarchy)
        {
            taskObj.SetActive(false);
        }
    }

    private void Awake()
    {
        _answerBody = GameObject.FindGameObjectWithTag("AnswerBody").GetComponent<Text>();
        //_answerBody = GameObject.Find("Body").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
