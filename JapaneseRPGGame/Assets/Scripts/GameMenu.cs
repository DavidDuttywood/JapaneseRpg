using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BigData;
using System;
using static BigData.TestData;

public class GameMenu : MonoBehaviour
{
    private Animator animator;
    public Button toggleMenu;
    public GameObject gameMenu;
    public GameObject objectiveList;
    public GameObject objectiveDetails;
    public Button buttonTemplate;
    public GameProgress gp;

    public bool isOpen;

    void Start()
    {
        gp = GameObject.Find("persistantGameStuff").GetComponentInChildren<GameProgress>();

        List<TestData.ObjectiveItem> objectives = TestData.GenerateObjectives();
        var objectivesInProgress = gp.objectiveProgress.ObjectivesInProgress;

        foreach (ObjectiveItem o in objectives)
        {
            if (objectivesInProgress.Contains(o.Id)) //filter through so the log shows ones that have been accepted
            {
                Button objective = Instantiate(buttonTemplate);
                objective.gameObject.SetActive(true);
                objective.GetComponentInChildren<Text>().text = o.ObjectiveName;
                objective.transform.SetParent(buttonTemplate.transform.parent, false);

                objective.onClick.AddListener(delegate
                {
                    ShowObjective(o.ObjectiveHelpText);
                });
            }
        }

        animator = GetComponent<Animator>();
        isOpen = false;
        gameMenu.SetActive(false);
    }

    public void AddObjectiveToList(int objectiveId) 
    {
        List<TestData.ObjectiveItem> objectives = TestData.GenerateObjectives();
        var o = objectives.Find(x => x.Id == objectiveId);

        if (o != null) 
        {
            Button objective = Instantiate(buttonTemplate);
            objective.gameObject.SetActive(true);
            objective.GetComponentInChildren<Text>().text = o.ObjectiveName;
            objective.transform.SetParent(buttonTemplate.transform.parent, false);

            objective.onClick.AddListener(delegate
            {
                ShowObjective(o.ObjectiveHelpText);
            });
        }
    }

    public void ShowObjective(string objective)
    {
        objectiveDetails.GetComponentInChildren<Text>().text = objective;
    }

    public void ToggleMenu()
    {
        if (isOpen)
        {
            isOpen = false;
            gameMenu.SetActive(false);

            //animator.SetTrigger("CloseMenu");
        }
        else
        {
            isOpen = true;
            gameMenu.SetActive(true);

            //animator.SetTrigger("OpenMenu");
        }
    }


}
