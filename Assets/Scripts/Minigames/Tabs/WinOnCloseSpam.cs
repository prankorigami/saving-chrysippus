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

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("closeTabSpam");
            CloseSpam();
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