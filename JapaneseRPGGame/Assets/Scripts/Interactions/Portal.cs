using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string destination;
    private SceneTransitionManager stm;
    public Vector2 destinationPosition;
    public int objectiveId;

    void Start()
    {
        stm = FindObjectOfType<SceneTransitionManager>();
    }

    public void Interact()
    {
        GameManager.instance.playerLocation = new GameProgress.PlayerLocation()
        {
            playerPositionX = destinationPosition.x,
            playerPositionY = destinationPosition.y,
        };

        if(objectiveId > 0)
        {
            GameManager.instance.MarkObjectiveAsCompleted(objectiveId);
        }

        GameManager.instance.SetPlayerLocation();
        stm.LoadLevel(destination);
    }
}