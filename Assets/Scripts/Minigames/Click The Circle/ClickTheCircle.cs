using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTheCircle : MinigameController
{
    [SerializeField] private GameObject circleToClick;
    [SerializeField] private Vector2 xBounds;
    [SerializeField] private Vector2 yBounds;

    // Sets up any randomized aspects of the mini-game here that might be
    // inconsistent with how the prefab spawns.
    public override void GameStart(int difficulty)
    {
        // Important to include: allows the base class to set up the minigame timer.
        base.GameStart(difficulty);

        Vector2 circlePos = Vector2.zero;
        circlePos.x = Random.Range(xBounds.x, xBounds.y);
        circlePos.y = Random.Range(yBounds.x, yBounds.y);
        circleToClick.transform.position = circlePos;

        circleToClick.transform.localScale = Vector3.one * (1.25f - (0.25f * difficulty));
    }

    // Runs primary game logic, though this can also be deferred to additional scripts.
    protected override void Update()
    {
        // Important to include: allows the 
        base.Update();
    }
}
