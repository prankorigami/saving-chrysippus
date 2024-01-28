using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AthenaReassembly : MinigameController
{
    [SerializeField] private GameObject spear;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject body;
    [SerializeField] private Vector2 xBounds;
    [SerializeField] private Vector2 yBounds;

    public override void GameStart(int difficulty)
    {
        base.GameStart(difficulty);

        Vector2 piecePos = Vector2.zero;
        piecePos.x = Random.Range(xBounds.x, xBounds.y);
        piecePos.y = Random.Range(yBounds.x, yBounds.y);
        spear.transform.position = piecePos;

        piecePos.x = Random.Range(xBounds.x, xBounds.y);
        piecePos.y = Random.Range(yBounds.x, yBounds.y);
        shield.transform.position = piecePos;

        piecePos.x = Random.Range(xBounds.x, xBounds.y);
        piecePos.y = Random.Range(yBounds.x, yBounds.y);
        body.transform.position = piecePos;
    }

    // Runs primary game logic, though this can also be deferred to additional scripts.
    protected override void Update()
    {
        // Important to include: allows the 
        base.Update();
    }
}
