using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginNewObjective : MonoBehaviour //rename to "Objective"
{
    public int objectiveId;
    public SpriteRenderer objectiveMarker;

    private void Start()
    {
        objectiveMarker = FindObjectOfType<SpriteRenderer>(); //taregets wrong rendered
        //go to game manager and set color based on where it is in the logs
    }

    public void Accept()
    {
        //add little pop up alert;
        GameManager.instance.BeginNewObjective(objectiveId);
        objectiveMarker.color = Color.magenta;
    }
}
