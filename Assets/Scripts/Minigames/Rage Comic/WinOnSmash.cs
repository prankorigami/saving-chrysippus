using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WinOnSmash : MonoBehaviour
{
    [SerializeField] private MinigameController controller;
    [SerializeField] private AudioSource hit;
    [SerializeField] private AudioSource destory;
    Animator anim;
    private int punchCounter = 0;
    private bool lastLeft = false;
    private bool over = false;

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
        if (punchCounter >= 10 && !over)
        {
            over = true;
            anim.Play("breakSlab");
            destory.Play();
            controller.StopTimer();
        }
    }

    private void HitSlab()
    {
        anim.Play("hitSlab");
        lastLeft = !lastLeft;
        punchCounter++;
        hit.Play();
    }

    public void GameEnd()
    {
        controller.WinGame();
    }
}