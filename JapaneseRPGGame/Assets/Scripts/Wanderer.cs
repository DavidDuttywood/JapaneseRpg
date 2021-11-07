using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For NPC's that move in fixed 2d areas.
public class Wanderer : Mover
{
    public bool isWalking;
    public float walkTime;
    public string movementPattern; //bit shit - not type checked or exhaustive
    public float waitTime;
    private float walkCounter;
    private float waitCounter;

    private int walkDirection;

    protected override void Start()
    {
        base.Start();
        waitCounter = waitTime;
        walkCounter = walkTime;
        ChooseDirection();
    }

    public void ChooseDirection()
    {
        int nextDirection = GetNextDirection(); //Random.Range(0, 4);
        if (walkDirection != nextDirection)
        {
            walkDirection = nextDirection;
            isWalking = true;
            walkCounter = walkTime;
        }
        else
        {
            //recursive loop designed such that the npc cant go the same way twice
            ChooseDirection();
        }
    }

    public int GetNextDirection() {
        switch (movementPattern)
        {
            case "Horizontal":
                return Random.Range(2, 4);
            case "Vertical":
                return Random.Range(0, 2);
            default:
                return Random.Range(0, 4);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //stop walking and make the play stand still
        if (col.collider.name == "Player")
        {
            canMove = false;
        }

        isWalking = false;
        waitCounter = waitTime;
    }

    void OnCollisionExit2D(Collision2D col)
    {
        canMove = true;
    }

    private void Wander(Vector2 movement)
    {
        if (canMove)
        {
            UpdateMotor(movement);
        }
    }

    void Update()
    {
        if (canMove)
        {
            if (isWalking)
            {
                walkCounter -= Time.deltaTime;
                if (walkCounter < 0)
                {
                    isWalking = false;
                    waitCounter = waitTime;
                }

                switch (walkDirection)
                {
                    case 0:
                        Wander(new Vector2(0, 1));
                        break;

                    case 1:
                        Wander(new Vector2(0, -1));
                        break;

                    case 2:
                        Wander(new Vector2(-1, 0));
                        break;

                    case 3:
                        Wander(new Vector2(1, 0));
                        break;
                }
            }
            else
            {
                animator.SetFloat("Horizontal", 0);
                animator.SetFloat("Vertical", 0);
                animator.SetFloat("Speed", 0);

                waitCounter -= Time.deltaTime;
                if (waitCounter < 0)
                {
                    ChooseDirection();
                }
            }
        }
        else
        {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
        }
    }
}
