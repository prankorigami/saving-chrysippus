using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public class MiniEndEvent : UnityEvent<bool> { }
    public static MiniEndEvent minigameEnds = new();

    [SerializeField] private float time;
    private float startTime;
    [SerializeField] private int score;
    [SerializeField] List<GameObject> minigamePrefs;
    MinigameController currentMinigame;

    [SerializeField] RectTransform timerBar;
    [SerializeField] RectTransform timerTransform;

    [SerializeField] Vector3 figPlacementPosition;
    [SerializeField] GameObject figPrefab;

    private void Start()
    {
        startTime = time;
        minigameEnds.AddListener(OnMinigameEnd);
        PickMinigame();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timerTransform.anchoredPosition = Vector3.up * (Mathf.Lerp(398, 12, time / startTime)) + new Vector3(-42, 0, 0);

        // Win Condition
        if( time <= 0 )
        {
            // currentMinigame.LoseGame();
        }
    }

    void PickMinigame()
    {
        // Randomly choose a game from the list and instantiate it
        int gamePickedIdx = Random.Range( 0, minigamePrefs.Count );
        currentMinigame = Instantiate( minigamePrefs[ gamePickedIdx ] ).GetComponent<MinigameController>();

        // Play the sprite spawning animation to show the enemy approaching
        StartCoroutine(WaitForAnimationToFinish());

        // Start the game
        currentMinigame.GameStart(0);
    }

    void OnMinigameEnd( bool gameResult )
    {
        // Change the Score based on the result of the game
        if(gameResult)
        {
            score++;
            // Add a fig icon to show your score
            RectTransform newFigIcon = Instantiate(figPrefab).GetComponent<RectTransform>();
            newFigIcon.anchoredPosition = figPlacementPosition;
            figPlacementPosition -= figPlacementPosition.x == -364 ? new Vector3(-27, 16, 0) : new Vector3(27, 16, 0);
        }
        time += gameResult ? 1f : -1f;

        // Destroy the object(s) associated with the previous minigame
        Destroy(currentMinigame);
        currentMinigame = null;

        // Pick the next minigame if the game isnt done
        if ( time > 0 )
        {
            PickMinigame();
        }
        else
        {
            EndGame();
        }
    }

    void EndGame()
    {
        // insert code here to run when the game ends
    }

    IEnumerator WaitForAnimationToFinish()
    {
        yield return new WaitForSeconds(5);
    }
}
