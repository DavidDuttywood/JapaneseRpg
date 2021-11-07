using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointArrayPatrol : Patrol
{
    public Transform[] patrolPoints;
    private int nextPoint;
    private Vector2 nextPointVector;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override Vector2 GetNextMovePoint()
    {

        if (nextPoint < patrolPoints.Length)
        {
            nextPointVector = new Vector2(patrolPoints[nextPoint].position.x, patrolPoints[nextPoint].position.y);
            nextPoint++;
        }
        else
        {
            nextPoint = 0;
            nextPointVector = new Vector2(patrolPoints[nextPoint].position.x, patrolPoints[nextPoint].position.y);
        }

        return nextPointVector;
    }
}
