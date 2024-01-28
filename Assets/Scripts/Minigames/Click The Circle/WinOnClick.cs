using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinOnClick : MonoBehaviour
{
    [SerializeField] private MinigameController controller;
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            controller.WinGame();
        }
    }
}
