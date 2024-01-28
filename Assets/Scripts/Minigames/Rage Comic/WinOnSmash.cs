using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WinOnSmash : MonoBehaviour
{
    [SerializeField] private MinigameController controller;
    Animator anim;
    private int punchCounter = 0;
    private bool lastLeft = false;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("left") && !lastLeft && punchCounter < 10)
            HitSlab();
        if (Input.GetKeyDown("right") && lastLeft && punchCounter < 10)
            HitSlab();
        if (punchCounter >= 10)
        {
            anim.Play("breakSlab");
            controller.StopTimer();
        }
    }

    private void HitSlab()
    {
        anim.Play("hitSlab");
        lastLeft = !lastLeft;
        punchCounter++;
    }

    public void GameEnd()
    {
        controller.WinGame();
    }
}