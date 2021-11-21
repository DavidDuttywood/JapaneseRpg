using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Objective : MonoBehaviour //rename to "Objective"
{
    public int objectiveId;
    public SpriteRenderer objectiveMarker;

    private bool objectiveInProgress;
    private bool objectiveIsCompleted;

    private void Start()
    {
        objectiveMarker = GetComponentInChildren<SpriteRenderer>();
        UpdateProgressMarker();
    }

    private void UpdateProgressMarker()
    {
        objectiveInProgress = GameManager.instance.objectiveProgress.ObjectivesInProgress.Contains(objectiveId);
        objectiveIsCompleted = GameManager.instance.objectiveProgress.ObjectivesCompleted.Contains(objectiveId);

        if (objectiveInProgress)
        {
            objectiveMarker.color = Color.yellow;
        }
        else if (objectiveIsCompleted)
        {
            Destroy(this);
        }
        else //not started
        {
            objectiveMarker.color = Color.green;
        }
    }

    public void Accept()
    {
        //add little pop up alert;
        GameManager.instance.BeginNewObjective(objectiveId);
        UpdateProgressMarker();
    }

    public void Complete()
    {
        GameManager.instance.MarkObjectiveAsCompleted(objectiveId);
        UpdateProgressMarker();
    }
}
