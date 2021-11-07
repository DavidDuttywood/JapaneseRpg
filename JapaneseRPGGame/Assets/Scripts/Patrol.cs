using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    private float waitTime;
    private Rigidbody2D rb;
    public Transform moveSpot;
    private bool canMove;

    //set these boundaries for every npc
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    void Start()
    {
        canMove = true;
        waitTime = 0;
        rb = GetComponent<Rigidbody2D>();
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //stop walking and make the play stand still
        if (col.collider.name == "Player")
        {
            canMove = false;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        StartCoroutine(wait());
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        canMove = true;
    }

    void Update()
    {
        if (canMove)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveSpot.position) < 0.1f)
            {
                if (waitTime <= 0)
                {
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    waitTime = Random.Range(2, 8);
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

}
