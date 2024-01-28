using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabs : MinigameController
{
    [SerializeField] private GameObject spamTab;
    [SerializeField] private GameObject mainTab;
    [SerializeField] private Vector2 xBounds;
    [SerializeField] private Vector2 yBounds;

    // Sets up any randomized aspects of the mini-game here that might be
    // inconsistent with how the prefab spawns.
    public override void GameStart(int difficulty)
    {
        // Important to include: allows the base class to set up the minigame timer.
        base.GameStart(difficulty);
        Vector2 tabPos = Vector2.zero;
        tabPos.x = UnityEngine.Random.Range(xBounds.x, xBounds.y);
        tabPos.y = UnityEngine.Random.Range(yBounds.x, yBounds.y);
        mainTab.transform.position = tabPos;
    }

    // Runs primary game logic, though this can also be deferred to additional scripts.
    protected override void Update()
    {
        // Important to include: allows the 
        base.Update();
    }
}
