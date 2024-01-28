using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WinOnCloseMain : MonoBehaviour
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
        anim.Play("closeMain");
    }
        

    public void GameEnd()
    {
        controller.WinGame();
    }
}