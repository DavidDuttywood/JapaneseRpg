using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//base for anything that moves
//test version control
public abstract class Mover : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDelta;
    protected float moveSpeed = 3.0f;
    public Animator animator;

    public bool canMove;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    protected virtual void UpdateMotor(Vector2 input)
    {
        if (canMove)
        {
            if (input.sqrMagnitude != 0)
            {
                animator.SetFloat("LastHorizontal", input.x);
                animator.SetFloat("LastVertical", input.y);
            }
        
            animator.SetFloat("Horizontal", input.x);
            animator.SetFloat("Vertical", input.y);
            animator.SetFloat("Speed", input.sqrMagnitude);

            moveDelta = new Vector2(input.x, input.y);
        
            rb.MovePosition(rb.position + moveDelta * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
