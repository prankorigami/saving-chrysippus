using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WinOnCloseSpam : MonoBehaviour
{
    [SerializeField] private MinigameController controller;
    Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void OnMouseClick()
    {
        CloseSpam();
        controller.StopTimer();
    }

    private void CloseSpam()
    {
        anim.Play("closeSpam");
    }

    public void GameEnd()
    {
        controller.WinGame();
    }
}