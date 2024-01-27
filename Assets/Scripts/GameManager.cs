using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public class MiniEndEvent : UnityEvent<bool> { }
    public static MiniEndEvent minigameEnds = new MiniEndEvent();

    [ SerializeField ] private float time;
    [ SerializeField ] private int score;
    List<GameObject>minigamePrefs = new List<GameObject>();
    GameObject currentMinigame;
    

    private void Start()
    {
        minigameEnds.AddListener(OnMinigameEnd);
        PickMinigame();
    }

    void PickMinigame()
    {
        // Randomly choose a game from the list and instantiate it
        int gamePickedIdx = Random.Range( 0, minigamePrefs.Count );
        currentMinigame = Instantiate( minigamePrefs[ gamePickedIdx ] );
        MinigameController gameController = currentMinigame.GetComponent<MinigameController>();

        // Play the sprite spawning animation to show the enemy approaching

        // Start the game
        gameController.GameStart();
    }

    void OnMinigameEnd( bool gameResult )
    {
        // Change the Score based on the result of the game
        score += gameResult ? 1 : 0;
        time += gameResult ? 1f : -1f;

        // Pick the next minigame
        PickMinigame();
    }
}
