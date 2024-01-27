using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines standardized functions for interfacing with the GameManager and the main game loop.
/// Designers should INHERIT FROM this class when designing their unique minigames.
/// </summary>
public class MinigameController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer backgroundSprite;
    
    // Currently set up with distinct game speeds in mind. In the future, change to be a smooth curve?
    // Index corresponds to 'difficulty' provided.
    [SerializeField] private float[] timesToBeat;
    private float miniTimer;

    // Sets up any randomized aspects of the mini-game that might be
    // inconsistent with how the prefab spawns.
    public virtual void GameStart(int difficulty)
    {
        miniTimer = timesToBeat[difficulty];
    }

    // Runs primary game logic, though this can also be deferred to additional scripts.
    protected virtual void Update()
    {
        miniTimer -= Time.deltaTime;
        if (miniTimer <= 0)
            LoseGame();
    }

    // Tells the GameManager that this minigame was completed successfully.
    public void WinGame() { GameManager.minigameEnds.Invoke(true); }

    // Tells the GameManager that this minigame was failed -- lose condition OR out of time.
    public void LoseGame() { GameManager.minigameEnds.Invoke(false); }
}
