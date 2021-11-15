using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    private Animator animator;
    public Button toggleMenu;
    public bool isOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
        isOpen = false;
    }

    public void ToggleMenu()
    {
        if (isOpen)
        {
            isOpen = false;
            animator.SetTrigger("CloseMenu");
        }
        else
        {
            isOpen = true;
            animator.SetTrigger("OpenMenu");
        }
    }

}
