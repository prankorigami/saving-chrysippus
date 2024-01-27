using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public class MiniEndEvent : UnityEvent<bool> { }
    public static MiniEndEvent minigameEnds = new MiniEndEvent();

    [SerializeField] private float time;
    private float startTime;
    [SerializeField] private int score;
    List<GameObject> minigamePrefs = new List<GameObject>();
    MinigameController currentMinigame;

    [SerializeField] RectTransform timerBar;
    [SerializeField] RectTransform timerTransform;

    private void Start()
    {
        startTime = time;
        minigameEnds.AddListener(OnMinigameEnd);
        PickMinigame();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        Debug.Log(Vector3.up * (Mathf.Lerp(0, timerBar.sizeDelta.y, time / startTime)));
        timerTransform.anchoredPosition = Vector3.up * (Mathf.Lerp(0, timerBar.sizeDelta.y, time / startTime));
    }

    void PickMinigame()
    {
        // Randomly choose a game from the list and instantiate it
        int gamePickedIdx = Random.Range( 0, minigamePrefs.Count );
        currentMinigame = Instantiate( minigamePrefs[ gamePickedIdx ] ).GetComponent<MinigameController>();

        // Play the sprite spawning animation to show the enemy approaching

        // Start the game
        currentMinigame.GameStart();
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
