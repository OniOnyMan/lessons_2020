using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeWorkController : MonoBehaviour
{
    public InputField TaskInput;
    public InputField ResearchInput;

    private Text _answerText;

    public void OnButtonPressed()
    {
        int taskValue = int.Parse(TaskInput.text);
        int researchValue = int.Parse(ResearchInput.text);

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
        _answerText = GameObject.Find("AnswerText").GetComponent<Text>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update is called");
    }

    private void FixedUpdate()
    {
        Debug.Log("FixedUpdate is called");
    }
}
