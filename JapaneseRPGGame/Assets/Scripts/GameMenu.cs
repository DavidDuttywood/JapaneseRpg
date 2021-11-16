using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    private Animator animator;
    public Button toggleMenu;
    public GameObject gameMenu;
    public GameObject objectiveList;
    public GameObject objectiveDetails;

    public bool isOpen;

    void Start()
    {
        List<string> objectives = new List<string>();
        objectives.Add("Go to the shop");
        objectives.Add("Get your hair did");
        objectives.Add("Talk to the maid");
        objectives.Add("Find a sushi place to eat");

        //need to store a starting position and then offset it each loop iteration
        //finally add a mask and scroll rect with a content sizer

        var appendLocation = objectiveDetails.transform.position;

        //foreach (string o in objectives)
        //{
        //    Button objective = Instantiate(Resources.Load("Objective", typeof(Button))) as Button;
        //    objective.GetComponentInChildren<Text>().text = o;
        //    objective.transform.SetParent(objectiveList.transform);

        //    objective.onClick.AddListener(delegate { ShowObjective(o); });
        //}

        animator = GetComponent<Animator>();
        isOpen = false;
        gameMenu.SetActive(false);
    }

    public void ShowObjective(string objective)
    {
        objectiveDetails.GetComponentInChildren<Text>().text = objective + " description text";
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
