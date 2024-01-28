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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("closeTabMain");
            CloseSpam();
            controller.StopTimer();
            GameEnd();
        }
    }

    private void CloseSpam()
    {
        Destroy(gameObject);
    }
        

    public void GameEnd()
    {
        controller.WinGame();
    }
}