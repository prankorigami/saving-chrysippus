using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ComedyShow : MinigameController
{
    [SerializeField] private GameObject[] hands;
    [SerializeField] private AudioClip jester;
    private int numTomatos = 0;
    private float winTimer = -1f;
    //[SerializeField] private Vector2 xBounds;
    //[SerializeField] private Vector2 yBounds;

    // Sets up any randomized aspects of the mini-game here that might be
    // inconsistent with how the prefab spawns.
    public override void GameStart(int difficulty)
    {
        // Important to include: allows the base class to set up the minigame timer.
        base.GameStart(difficulty);
        numTomatos = hands.Length;
        for (int i = 0; i < hands.Length; i++)
        {
            hands[i].GetComponent<HandClick>().game = this;
            hands[i].transform.localPosition = new Vector3(1.5f*(Random.Range(i+0.1f, i + 0.9f)*2f/hands.Length - 1f), Random.Range(-0.35f, -1.4f), -1f);
        }

        GetComponent<AudioSource>().clip = jester;
        GetComponent<AudioSource>().time = Random.Range(0f, jester.length);
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().Play();
    }

    // Runs primary game logic, though this can also be deferred to additional scripts.
    protected override void Update()
    {
        // Important to include: allows the 
        base.Update();
        if (winTimer > 0) {
            winTimer -= Time.deltaTime;
            if (winTimer < 0) {
                WinGame();
            }
        }
    }

    public void splat() {
        numTomatos--;
        if (numTomatos <= 0) {
            // maybe do an animation, via state and update
            // StopTimer() // @pranav
            GetComponent<AudioSource>().Stop();
            winTimer = 1f;
        }
    }
}
