using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BigData;
using System;

public class GameMenu : MonoBehaviour
{
    private Animator animator;
    public Button toggleMenu;
    public GameObject gameMenu;
    public GameObject objectiveList;
    public GameObject objectiveDetails;
    public Button buttonTemplate;

    public bool isOpen;

    void Start()
    {

        List<TestData.Objective> objectives = TestData.GenerateObjectives();

        foreach (TestData.Objective o in objectives)
        {
            Button objective = Instantiate(buttonTemplate);
            objective.gameObject.SetActive(true);
            objective.GetComponentInChildren<Text>().text = o.ObjectiveName;
            objective.transform.SetParent(buttonTemplate.transform.parent, false);

            objective.onClick.AddListener(delegate { ShowObjective(o.ObjectiveHelpText); });
        }

        animator = GetComponent<Animator>();
        isOpen = false;
        gameMenu.SetActive(false);
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
