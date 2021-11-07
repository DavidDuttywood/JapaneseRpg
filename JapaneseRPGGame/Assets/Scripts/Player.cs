using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    public Vector2 movement;
    public Joystick stick;
    public Transform interactor;
    public SpriteRenderer spriteRenderer;

    protected override void Start()
    {
        base.Start();
        //this doesnt persist between scene changes
        //need a static global object
        //transform.position = GameManager.instance.playerTransform.position;
        //transform.position = new Vector3(1, 1, 0);
        spriteRenderer = GetComponent<SpriteRenderer>();
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
