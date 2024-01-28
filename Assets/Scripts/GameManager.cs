using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public class MiniEndEvent : UnityEvent<bool> { }
    public static MiniEndEvent minigameEnds = new();

    public static UnityEvent animationEnd = new();

    [SerializeField] private float time;

    private float startTime;
    [SerializeField] private int score;
    [SerializeField] List<GameObject> minigamePrefs;
    [SerializeField] List<Sprite> minigameEnemies;
    [SerializeField] GameObject baseEnemy;
    int gamePicked = -1;
    GameObject currentMinigameObject;
    GameObject newEnemy;
    [SerializeField] GameObject background;
    MinigameController currentMinigame;

    [SerializeField] RectTransform timerBar;
    [SerializeField] RectTransform timerTransform;

    [SerializeField] Vector3 figPlacementPosition;
    [SerializeField] GameObject figPrefab;
    [SerializeField] Transform canvas;

    private void Start()
    {
        startTime = time;
        minigameEnds.AddListener(OnMinigameEnd);
        animationEnd.AddListener(OnAnimationFinish);
        PickMinigame();
    }

    private void Update()
    {
        time -= Time.deltaTime;
        timerTransform.anchoredPosition = Vector3.up * (Mathf.Lerp(398, 12, time / startTime)) + new Vector3(-42, 0, 0);

        // Win Condition
        if( time <= 0 )
        {
            currentMinigame.LoseGame();
        }
    }

    void PickMinigame()
    {
        // Randomly choose a game from the list
        gamePicked = Random.Range(0, minigamePrefs.Count);

        // Play the sprite spawning animation to show the enemy approaching
        background.GetComponent<Animator>().Play("ForwardMoveAnimation");
        newEnemy = Instantiate(baseEnemy, new Vector3(0f, -0.69f, 0f), Quaternion.identity);
        newEnemy.GetComponent<SpriteRenderer>().sprite = minigameEnemies[gamePicked];
    }

    void OnMinigameEnd( bool gameResult )
    {
        // Change the Score based on the result of the game
        if(gameResult)
        {
            score++;
            // Add a fig icon to show your score
            GameObject newFig = Instantiate(figPrefab);
            newFig.transform.SetParent(canvas);
            newFig.GetComponent<RectTransform>().anchoredPosition = figPlacementPosition;
            figPlacementPosition -= new Vector3(0, 10, 0);
        }
        time += gameResult ? 1f : -1f;

        // Destroy the object(s) associated with the previous minigame
        Destroy(currentMinigameObject);
        newEnemy.GetComponent<Animator>().Play("EnemyDie");
        currentMinigame = null;
        gamePicked = -1;

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

    void OnAnimationFinish()
    {
        currentMinigameObject = Instantiate(minigamePrefs[gamePicked]);
        currentMinigame = currentMinigameObject.GetComponent<MinigameController>();

        // Start the game
        currentMinigame.GameStart(0);
    }
}
