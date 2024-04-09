using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    [SerializeField] float timerToCompleteQuestion = 20f;
    [SerializeField] float timeToShowCorrectAnswer = 8f;

    public bool loadNextQuestion;
    public bool isAnsweringQuestion;
    public float fillFraction;

    [SerializeField] Image timerImage;
    float timerValue;



    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }
    
    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timerToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;              
                timerValue = timeToShowCorrectAnswer;

            }
        }
        else
        {
            if (timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;

            }
            else
            {
                isAnsweringQuestion = true;
                loadNextQuestion = true;
                timerValue = timerToCompleteQuestion;
               
            }
        }
    }
}
