using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    private Animator animator;
    public Button toggleMenu;
    public GameObject gameMenu;
    public bool isOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = false;
        gameMenu.SetActive(false);
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
