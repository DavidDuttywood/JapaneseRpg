using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPatrol : Patrol
{
    //set these boundaries for every npc
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

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
        return new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
    }

}
