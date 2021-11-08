using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    private Rigidbody2D rb;
    public Vector2 moveSpot;
    public bool canMove;
    public Animator animator;

    protected virtual void Start()
    {
        speed = 3f;
        canMove = true;
        waitTime = 0;
        rb = GetComponent<Rigidbody2D>();
        moveSpot = GetNextMovePoint();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //stop walking and make the npc stand still
        if (col.collider.name == "Player")
        {
            canMove = false;
            animator.SetFloat("Speed", 0);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        animator.SetFloat("Speed", 1);
        canMove = true;
    }

    protected virtual void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
            if (animator.GetFloat("Speed") == 1)
            {
                animator.SetFloat("LastHorizontal", (moveSpot.x - transform.position.x));
                animator.SetFloat("LastVertical", (moveSpot.y - transform.position.y));
            }

            animator.SetFloat("Horizontal", (moveSpot.x - transform.position.x));
            animator.SetFloat("Vertical", (moveSpot.y - transform.position.y));
            animator.SetFloat("Speed", 1);


            if (Vector2.Distance(transform.position, moveSpot) < 0.1f)
            {
                animator.SetFloat("Speed", 0);
                if (waitTime <= 0)
                {
                    moveSpot = GetNextMovePoint();

                    waitTime = Random.Range(2, 8);
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    protected virtual Vector2 GetNextMovePoint()
    {
        return new Vector2(0, 0);
    }
}
