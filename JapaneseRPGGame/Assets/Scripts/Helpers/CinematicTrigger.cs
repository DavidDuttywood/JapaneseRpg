using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CinematicTrigger : MonoBehaviour
{
    public PlayableDirector timeline;
    public bool hasPlayed;
    public Player player;

    void Start()
    {
        hasPlayed = false;
        timeline = GetComponent<PlayableDirector>();
        player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "Player" && !hasPlayed)
        {
            player.canMove = false;
            player.animator.SetFloat("Speed", 0);
            StartCoroutine("PlayAnimation");
        }
    }
    IEnumerator PlayAnimation()
    {
        timeline.Play();
        yield return new WaitForSeconds((float)timeline.duration);
        //player.canMove = true;
        hasPlayed = true;
    }
}
