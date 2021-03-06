﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayDayController : MonoBehaviour
{
    private UiLevelController uiController;
    int indexPanel;

    private void Start()
    {
        uiController = FindObjectOfType<UiLevelController>();
    }

    public void HidePanelSemester()
    {
        uiController.daysText.SetActive(false);
        uiController.gridContainePanel.GetChild(indexPanel).gameObject
            .SetActive(false);
    }

    public void HandlerChildContainer(int index)
    {
        indexPanel = index;
        uiController.daysText.SetActive(true);
        uiController.gridContainePanel.GetChild(index).gameObject
            .SetActive(true);
        SelectDay();
    }

    public void SelectDay()
    {
        Transform days = uiController.gridContainePanel.GetChild(indexPanel)
            .Find("ContainerDays");

        for (int i = 0; i < days.childCount; i++)
        {
            Button button = days.GetChild(i).GetComponent<Button>();
            button.name = i.ToString();
            button.onClick.AddListener(() => PlayDay(indexPanel.ToString(),button.name));
        }
    }

    public void PlayDay(string semester, string day)
    {
        SceneManager.LoadScene($"Semester{semester}_{day}");
    }

}

