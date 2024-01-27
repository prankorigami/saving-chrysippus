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
    [SerializeField] List<GameObject> minigamePrefs = new List<GameObject>();
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
    }

    void PickMinigame()
    {
        // Randomly choose a game from the list and instantiate it
        int gamePickedIdx = Random.Range( 0, minigamePrefs.Count );
        currentMinigame = Instantiate( minigamePrefs[ gamePickedIdx ] ).GetComponent<MinigameController>();
        Debug.Log("penis");
        // Play the sprite spawning animation to show the enemy approaching
        StartCoroutine(WaitForAnimationToFinish());
        Debug.Log("penis2");
        // Start the game
        currentMinigame.GameStart();
    }

    void OnMinigameEnd( bool gameResult )
    {
        // Change the Score based on the result of the game
        if(gameResult)
        {
            score++;
            RectTransform newFigIcon = Instantiate(figPrefab).GetComponent<RectTransform>();
            newFigIcon.anchoredPosition = figPlacementPosition;
            figPlacementPosition -= figPlacementPosition.x == -364 ? new Vector3(-27, 16, 0) : new Vector3(27, 16, 0);
        }
        time += gameResult ? 1f : -1f;

        // Pick the next minigame
        PickMinigame();
    }

    IEnumerator WaitForAnimationToFinish()
    {
        yield return new WaitForSeconds(5);
    }
}
