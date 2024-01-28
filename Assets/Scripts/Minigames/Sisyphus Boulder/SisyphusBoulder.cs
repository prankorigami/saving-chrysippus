using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SisyphusBoulder : MinigameController
{
    // 0 UP
    // 1 RIGHT
    // 2 DOWN
    // 3 LEFT
    private int inputStep = 0;
    [SerializeField] private float progDecayScale = 2;
    [SerializeField] private float progIncrement = 1f;
    [SerializeField] private float progress = 0;
    [SerializeField] private float progGoal = 10;

    [SerializeField] private GameObject[] arrowObjs;
    private GameObject currentArrow;

    [SerializeField] private LerpTowardsLoc boulder;
    [SerializeField] private LerpTowardsLoc man;

    [SerializeField] private GameObject arrowBlipPref;

    // Sets up any randomized aspects of the mini-game here that might be
    // inconsistent with how the prefab spawns.
    public override void GameStart(int difficulty)
    {
        // Important to include: allows the base class to set up the minigame timer.
        base.GameStart(difficulty);
        currentArrow = arrowObjs[inputStep];
        progDecayScale += difficulty;
    }

    // Runs primary game logic, though this can also be deferred to additional scripts.
    protected override void Update()
    {
        // Important to include: allows the 
        base.Update();

        progress = Mathf.Clamp(progress - (Time.deltaTime * progDecayScale), 0, float.MaxValue);

        bool inputMatched = false;
        switch(inputStep)
        {
            case 0:
                inputMatched = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
                break;
            case 1:
                inputMatched = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
                break;
            case 2:
                inputMatched = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
                break;
            case 3:
                inputMatched = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
                break;
        }

        if (inputMatched)
        {
            inputStep = (inputStep + 1) % 4;
            progress += progIncrement;

            currentArrow.SetActive(false);
            GameObject arrowBlipFX = Instantiate(arrowBlipPref);
            arrowBlipFX.transform.position = currentArrow.transform.position;
            arrowBlipFX.transform.eulerAngles = currentArrow.transform.eulerAngles;
            currentArrow = arrowObjs[inputStep];
            currentArrow.SetActive(true);

            if (progress >= progGoal)
                WinGame();
        }

        boulder.UpdatePosition(progress / progGoal);
        man.UpdatePosition(progress / progGoal);
    }
}
