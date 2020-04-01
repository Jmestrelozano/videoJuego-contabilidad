﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UiController : MonoBehaviour
{
    public Text titleQuestion;
    public Text endScore;
    public Text semesterName;
    public Text semesterNumber;
    public Transform answerButtonPanel;
    public GameObject prefabButton;
    private int answerNumber;

    // OPTIONAL en caso de que se decida que los parciales tengan tiempo activar
    //public Text timeQuiz;

    public void CreateButtonsAndInputs(Answer[] data)
    {
        answerNumber = data.Length;
        for (int i = 0; i < answerNumber; i++)
        {
            GameObject answerButtonGameObject = Instantiate(prefabButton);
            answerButtonGameObject.transform.SetParent(answerButtonPanel);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(data[i]);
        }

    }

    public void DeleteButtons()
    {
        Debug.Log(answerButtonPanel.childCount);
        for (int i = 0; i < answerNumber; i++)
        {
            Destroy(answerButtonPanel.GetChild(i).gameObject);
        }
    }
}

