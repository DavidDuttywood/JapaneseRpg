using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Mover
{
    public Vector2 movement;

    public Joystick stick;
    public Button interactButton;

    public Transform interactor;
    public SpriteRenderer spriteRenderer;
    public bool colliding;
    public Collider2D coll;

    protected override void Start()
    {
        base.Start();
        stick = FindObjectOfType<Joystick>();
        interactButton = GameObject.Find("Canvas/SafeArea/InteractButton").GetComponent<Button>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        GameManager.instance.player = this;
        GameManager.instance.LoadPlayerLocation();

        if (interactButton != null)
        {
            interactButton.interactable = true;
            interactButton.onClick.AddListener(delegate { InteractButtonClick(); });
        }
    }

    public void InteractButtonClick()
    {
        if (colliding && coll != null)
        {
            coll.SendMessage("Interact");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().GetType() != typeof(UnityEngine.Tilemaps.TilemapCollider2D)) //ignore walking into walls
        {
            colliding = true;
            coll = collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        colliding = false;
        coll = null;
    }

    private void FixedUpdate()
    {
        movement.x = stick.Horizontal;
        movement.y = stick.Vertical;

        switch (spriteRenderer.sprite.name)
        {
            case "playerIdleRight":
                interactor.localRotation = Quaternion.Euler(new Vector3(0, 0, 90));
                break;
            case "playerIdleLeft":
                interactor.localRotation = Quaternion.Euler(new Vector3(0, 0, -90));
                break;
            case "playerIdleUp":
                interactor.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
                break;
            case "playerIdleDown":
                interactor.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
                break;
        }

        UpdateMotor(new Vector2(movement.x, movement.y));
    }

    //this clicks but also updates the animator based off current sprite;
    //use this when invoking click from timeline animation.
    public void InteractClickFromTrigger() {
        switch (spriteRenderer.sprite.name)
        {
            case "playerWalkingRight":
            case "playerIdleRight":
                animator.SetFloat("LastHorizontal", 1f);
                animator.SetFloat("LastVertical", 0f);
                break;
            case "playerWalkingLeft":
            case "playerIdleLeft":
                animator.SetFloat("LastHorizontal", -1f);
                animator.SetFloat("LastVertical", 0f);
                break;
            case "playerWalkingUp":
            case "playerIdleUp":
                animator.SetFloat("LastHorizontal", 0f);
                animator.SetFloat("LastVertical", 1f);
                break;
            case "playerWalkingDown":
            case "playerIdleDown":
                animator.SetFloat("LastHorizontal", 0f);
                animator.SetFloat("LastVertical", -1f);
                break;
        }
        InteractButtonClick();
    }
}
