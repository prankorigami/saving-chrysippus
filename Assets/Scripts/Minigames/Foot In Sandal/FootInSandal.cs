using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootInSandal : MinigameController
{
    [SerializeField] private GameObject sandal;
    [SerializeField] private GameObject foot;
    [SerializeField] private Vector2 xFootBounds;
    [SerializeField] private Vector2 yBounds;
    [SerializeField] private Vector2 xShoeBounds;
    public override void GameStart(int difficulty)
    {
        base.GameStart(difficulty);

        Vector3 sandalPos = new Vector3(0, 0, -1);
        sandalPos.x = Random.Range(xFootBounds.x, xFootBounds.y);
        sandalPos.y = Random.Range(yBounds.x, yBounds.y);
        sandal.transform.position = sandalPos;

        Vector3 footPos = new Vector3(0, 0, -1);
        footPos.x = Random.Range(xShoeBounds.x, xShoeBounds.y);
        footPos.y = Random.Range(yBounds.x, yBounds.y);
        foot.transform.position = footPos;
    }

    protected override void Update()
    {
        base.Update();
    }
}
