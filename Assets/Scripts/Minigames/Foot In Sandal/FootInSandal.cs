using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootInSandal : MinigameController
{
    [SerializeField] private GameObject sandal;
    [SerializeField] private Vector2 xBounds;
    [SerializeField] private Vector2 yBounds;
    public override void GameStart(int difficulty)
    {
        base.GameStart(difficulty);

        Vector3 sandalPos = new Vector3(0, 0, -1);
        sandalPos.x = Random.Range(xBounds.x, xBounds.y);
        sandalPos.y = Random.Range(yBounds.x, yBounds.y);
        sandal.transform.position = sandalPos;
    }

    protected override void Update()
    {
        base.Update();
    }
}
