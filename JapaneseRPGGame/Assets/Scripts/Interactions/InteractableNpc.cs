using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNpc : Interactable
{
    private Animator animator;
    private Wanderer wanderer;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        wanderer = GetComponent<Wanderer>();
    }


    protected override void Interact()
    {
        wanderer.canMove = false;

        var playerHorizontal = GameManager.instance.player.animator.GetFloat("LastHorizontal");
        var playerVertical = GameManager.instance.player.animator.GetFloat("LastVertical");

        animator.SetFloat("LastHorizontal", playerHorizontal);
        animator.SetFloat("LastVertical", playerVertical);
    }
}
