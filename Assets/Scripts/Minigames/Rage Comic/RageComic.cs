using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageComic : MinigameController
{
    [SerializeField] private GameObject rageComicSlab;

    // Sets up any randomized aspects of the mini-game here that might be
    // inconsistent with how the prefab spawns.
    public override void GameStart(int difficulty)
    {
        // Important to include: allows the base class to set up the minigame timer.
        base.GameStart(difficulty);
    }

    // Runs primary game logic, though this can also be deferred to additional scripts.
    protected override void Update()
    {
        // Important to include: allows the 
        base.Update();
    }
}
