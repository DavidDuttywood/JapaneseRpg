using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string destination;
    private SceneTransitionManager stm;
    public Vector2 destinationPosition;

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

        GameManager.instance.SetPlayerLocation();
        stm.LoadLevel(destination);
    }
}