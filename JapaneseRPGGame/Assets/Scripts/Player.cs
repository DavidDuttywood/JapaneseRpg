using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public Vector2 movement;
    public Joystick stick;
    public Transform interactor;
    public SpriteRenderer spriteRenderer;
    public bool colliding;
    public Collider2D coll;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        colliding = true;
        coll = collision;
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
}
